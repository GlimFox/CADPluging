using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KompasAPI7;


namespace Kompas
{
    public class Wrapper
    {
        /// <summary>
        /// Обертка для взаимодействия с API Kompas
        /// </summary>

        /// <summary>
        /// Объект API для работы с Kompas
        /// </summary>
        private IKompasAPIObject _kompas;

        //private IKompasDocument3D document3d;

        /// <summary>
        /// Метод для открытия CAD-приложения
        /// </summary>
        public void OpenCAD()
        {
            Type t = Type.GetTypeFromProgID("KOMPAS.Application.7");
            _kompas = (IKompasAPIObject)Activator.CreateInstance(t);
            _kompas.Application.Visible = true;
        }

        /// <summary>
        /// Метод для создания части в 3D документе
        /// </summary>
        /// <returns>Возвращает созданную часть</returns>
        public IPart7 CreatePart()
        {
            _kompas.Application.Documents.Add(DocumentTypeEnum.ksDocumentPart);
            IKompasDocument3D document3d = (IKompasDocument3D)_kompas.Application.ActiveDocument;
            return document3d.TopPart;
        }

        /// <summary>
        /// Метод для создания эскиза на заданной части
        /// </summary>
        /// <param name="part">Часть, к которой добавляется эскиз</param>
        /// <param name="name">Имя создаваемого эскиза</param>
        /// <returns>Созданный эскиз</returns>
        public ISketch CreateSketch(IPart7 part, string name)
        {
            IModelContainer modelContainer = (IModelContainer)part;
            ISketch sketch = modelContainer.Sketchs.Add();
            sketch.Plane = part.DefaultObject[ksObj3dTypeEnum.o3d_planeXOY];
            sketch.Name = name;
            sketch.Hidden = false;
            sketch.Update();

            return sketch;
        }

        /// <summary>
        /// Метод для создания прямоугольника в эскизе
        /// </summary>
        /// <param name="sketch">Эскиз, в который добавляется прямоугольник</param>
        /// <param name="x">Координата X начальной точки</param>
        /// <param name="y">Координата Y начальной точки</param>
        /// <param name="width">Ширина прямоугольника</param>
        /// <param name="height">Высота прямоугольника</param>
        public void CreateRectangle(ISketch sketch, double x, double y, double width, double height)
        {
            IKompasDocument documentSketch = sketch.BeginEdit();
            IKompasDocument2D document2D = (IKompasDocument2D)documentSketch;
            IViewsAndLayersManager viewsAndLayersManager = document2D.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            IRectangle rectangle = drawingContainer.Rectangles.Add();
            rectangle.Style = (int)Kompas6Constants.ksCurveStyleEnum.ksCSNormal;
            rectangle.X = x;
            rectangle.Y = y;
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Update();
            sketch.EndEdit();
        }

        /// <summary>
        /// Метод для создания круга в эскизе
        /// </summary>
        /// <param name="sketch">Эскиз, в который добавляется круг</param>
        /// <param name="x">Координата X центра круга</param>
        /// <param name="y">Координата Y центра круга</param>
        /// <param name="diameter">Диаметр круга</param>
        public void CreateCircle(ISketch sketch, int x, int y, double diameter)
        {
            IKompasDocument documentSketch = sketch.BeginEdit();
            IKompasDocument2D document2D = (IKompasDocument2D)documentSketch;
            IViewsAndLayersManager viewsAndLayersManager = document2D.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ICircle circle = drawingContainer.Circles.Add();
            circle.Style = (int)Kompas6Constants.ksCurveStyleEnum.ksCSNormal;
            circle.Xc = x;
            circle.Yc = y;
            circle.Radius = diameter / 2;
            circle.Update();
            sketch.EndEdit();
        }

        /// <summary>
        /// Метод для экструзии эскиза
        /// </summary>
        /// <param name="sketch">Эскиз, который будет экструзирован</param>
        /// <param name="depth">Глубина экструзии</param>
        /// <param name="name">Имя экструзии</param>
        /// <param name="draftOutward">Флаг, указывающий направление экструзии</param>
        public void ExtrudeSketch(ISketch sketch, double depth, string name, bool draftOutward)
        {
            var part = sketch.Part;
            var modelContainer = (IModelContainer)part;
            var extrusions = modelContainer.Extrusions;

            IExtrusion extrusion = extrusions.Add(Kompas6Constants3D.ksObj3dTypeEnum.o3d_bossExtrusion);
            extrusion.Direction = Kompas6Constants3D.ksDirectionTypeEnum.dtNormal;
            extrusion.Name = name;
            extrusion.Hidden = false;
            extrusion.ExtrusionType[true] = Kompas6Constants3D.ksEndTypeEnum.etBlind;
            extrusion.DraftOutward[true] = draftOutward;
            extrusion.DraftValue[true] = 0.0;
            extrusion.Depth[true] = depth;

            IExtrusion1 extrusion1 = (IExtrusion1)extrusion;
            extrusion1.Profile = sketch;
            extrusion1.DirectionObject = sketch;
            extrusion.Update();
        }

        public void CreateLine(ISketch sketch, double x1, double y1, double x2, double y2)
        {
            IKompasDocument documentSketch = sketch.BeginEdit();
            IKompasDocument2D document2D = (IKompasDocument2D)documentSketch;
            IViewsAndLayersManager viewsAndLayersManager = document2D.ViewsAndLayersManager;
            IView view = viewsAndLayersManager.Views.ActiveView;
            IDrawingContainer drawingContainer = (IDrawingContainer)view;

            ILineSegment line = drawingContainer.LineSegments.Add();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Update();

            sketch.EndEdit();
        }

        /// <summary>
        /// Получение стандартной плоскости на основе типа
        /// </summary>
        /// <param name="part">Часть, из которой нужно получить стандартную плоскость</param>
        /// <param name="planeType">Тип стандартной плоскости (например, ksObj3dTypeEnum.o3d_planeXOZ)</param>
        /// <returns>Объект стандартной плоскости</returns>
        public object GetSidePlane(IPart7 part, ksObj3dTypeEnum planeType)
        {
            // Получаем стандартный объект плоскости
            var plane = part.DefaultObject[planeType];

            if (plane == null)
            {
                throw new InvalidOperationException("Не удалось получить стандартную плоскость.");
            }

            return plane; // Возвращаем объект
        }

        public ISketch CreateSketchOnPlane(IPart7 part, object plane, string name)
        {
            IModelContainer modelContainer = part as IModelContainer;
            if (modelContainer == null)
            {
                throw new InvalidOperationException("Не удалось преобразовать part к IModelContainer.");
            }

            ISketch sketch = modelContainer.Sketchs.Add(); // Добавляем эскиз через контейнер

            // Преобразуем объект plane к IModelObject
            sketch.Plane = plane as IModelObject;
            if (sketch.Plane == null)
            {
                throw new InvalidOperationException("Плоскость не может быть преобразована в IModelObject.");
            }

            sketch.Name = name;   // Устанавливаем имя
            sketch.Hidden = false; // Делаем эскиз видимым
            sketch.Update();

            return sketch;
        }

        /// <summary>
        /// Вырезать выдавливанием симметрично из указанного эскиза
        /// </summary>
        /// <param name="sketch">Эскиз для вырезания</param>
        /// <param name="depth">Глубина вырезания (в обе стороны от эскиза)</param>
        /// <param name="name">Имя операции вырезания</param>
        public void CutExtrudeSymmetric(ISketch sketch, double depth, string name)
        {
            // Получаем часть, к которой привязан эскиз
            var part = sketch.Part;
            if (part == null)
            {
                throw new InvalidOperationException("Эскиз не привязан к части.");
            }

            // Получаем контейнер операций для части
            var modelContainer = part as IModelContainer;
            if (modelContainer == null)
            {
                throw new InvalidOperationException("Не удалось преобразовать part к IModelContainer.");
            }

            // Добавляем операцию вырезания
            var extrusions = modelContainer.Extrusions;
            var cutExtrusion = extrusions.Add(Kompas6Constants3D.ksObj3dTypeEnum.o3d_cutExtrusion);

            cutExtrusion.Direction = Kompas6Constants3D.ksDirectionTypeEnum.dtBoth; // Симметричное направление
            cutExtrusion.Name = name; // Имя операции
            cutExtrusion.Hidden = false; // Сделать операцию видимой
            cutExtrusion.ExtrusionType[true] = Kompas6Constants3D.ksEndTypeEnum.etBlind; // Глубина вырезания
            cutExtrusion.Depth[true] = depth; // Устанавливаем глубину вырезания
            cutExtrusion.Depth[false] = depth; // Глубина в противоположную сторону
            cutExtrusion.DraftOutward[true] = false; // Без уклона
            cutExtrusion.DraftOutward[false] = false; // Без уклона в обе стороны

            // Привязываем профиль (эскиз) к операции вырезания
            var cutExtrusion1 = cutExtrusion as IExtrusion1;
            if (cutExtrusion1 == null)
            {
                throw new InvalidOperationException("Не удалось преобразовать выдавливание к IExtrusion1.");
            }

            cutExtrusion1.Profile = sketch; // Эскиз для вырезания
            cutExtrusion1.DirectionObject = sketch; // Направление вырезания от эскиза

            // Обновляем операцию вырезания
            cutExtrusion.Update();
        }

        /// <summary>
        /// Создаёт дугу в эскизе
        /// </summary>
        /// <param name="sketch">Эскиз, в котором создаётся дуга</param>
        /// <param name="startX">X-координата начала дуги</param>
        /// <param name="startY">Y-координата начала дуги</param>
        /// <param name="middleX">X-координата средней точки дуги</param>
        /// <param name="middleY">Y-координата средней точки дуги</param>
        /// <param name="endX">X-координата конца дуги</param>
        /// <param name="endY">Y-координата конца дуги</param>
        public void CreateArc(ISketch sketch, double startX, double startY, double middleX, double middleY, double endX, double endY)
        {
            // Получаем интерфейс 2D-документа для редактирования
            ksDocument2D doc2D = (ksDocument2D)sketch.BeginEdit();

            // Определяем центр и радиус дуги
            double radius = Math.Sqrt(Math.Pow(middleX - startX, 2) + Math.Pow(middleY - startY, 2));
            double centerX = (startX + endX) / 2; // Приблизительный центр по X
            double centerY = (startY + endY) / 2; // Приблизительный центр по Y

            // Углы начала и конца дуги
            double startAngle = Math.Atan2(startY - centerY, startX - centerX) * 180 / Math.PI;
            double endAngle = Math.Atan2(endY - centerY, endX - centerX) * 180 / Math.PI;

            // Создаём дугу в эскизе
            doc2D.ksArcBy3Points(
                startX, startY,  // Начальная точка
                middleX, middleY, // Точка на дуге
                endX, endY,       // Конечная точка
                1                // Направление построения (по часовой стрелке)
            );

            // Завершаем редактирование эскиза
            sketch.EndEdit();
        }

        // public void Spin()
        //{
        //    ksEntity entityRotate = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_bossRotated);
        //    if (entityRotate != null)
        //    {
        //        ksBossRotatedDefinition rotateDef =
        //            (ksBossRotatedDefinition)entityRotate.GetDefinition();
        //        if (rotateDef != null)
        //        {
        //            rotateDef.directionType = (short)Direction_Type.dtNormal;
        //            rotateDef.SetSideParam(false, 360);
        //            rotateDef.SetSketch(this._sketchEntity);  // эскиз операции вращения
        //            entityRotate.Create();              // создать операцию
        //        }
        //    }
        //}

    }
}
