using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

namespace Kompas
{
    /// <summary>
    /// Класс-обертка для работы с API Kompas3D.
    /// </summary>
    public class Wrapper
    {
        #region Features (Свойства)

        /// <summary>
        /// Поле для хранения приложения Компас.
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Поле для хранения выбранной 3d детали.
        /// </summary>
        private Kompas6API5.ksPart _part;

        /// <summary>
        /// Поле для хранения выбранного эскиза.
        /// </summary>
        private Kompas6API5.ksEntity _sketch;

        /// <summary>
        /// Поле для хранения выбранной плоскости.
        /// </summary>
        private Kompas6API5.ksEntity _plane;

        #endregion

        #region AppFunctions (Функции САПР)

        /// <summary>
        /// Создание документа в компасе.
        /// </summary>
        public void CreateFile()
        {
            ksDocument3D document3D;

            // Создаем новый документ (файл)
            document3D = (ksDocument3D)this._kompas.Document3D();
            document3D.Create();

            // Запоминаем текущий файл
            this._part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Открытие компаса.
        /// </summary>
        public void OpenCAD()
        {
            // Попытка подключения к уже запущенному процессу Kompas3D
            try
            {
                this._kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            }
            // Если процесс не найден, создается новый экземпляр
            catch
            {
                Type kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                if (kompasType != null)
                {
                    this._kompas = (KompasObject)Activator.CreateInstance(kompasType);
                }
            }

            if (this._kompas != null)
            {
                this._kompas.Visible = true;
                this._kompas.ActivateControllerAPI();
            }
            else
            {
                throw new Exception("Не удалось запустить или подключиться к Kompas3D.");
            }
        }
        #endregion

        /// <summary>
        /// Создание эскиза (скетча) в компасе.
        /// </summary>
        /// <param name="plane">Выбранная плоскость.</param>
        public void CreateSketch(int plane)
        {
            if (this._part == null)
            {
                throw new Exception("Деталь (_part) не была инициализирована. " +
                    "Вызовите CreateFile() перед созданием эскиза.");
            }

            // Создаем эскиз и помещаем его в _sketch
            ksSketchDefinition sketch;
            this._sketch = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_sketch);
            sketch = (ksSketchDefinition)this._sketch.GetDefinition();

            // Выбор пространства для построения плоскости
            switch (plane)
            {
                case 1: 
                    this._plane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                    break;
                case 2: 
                    this._plane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                    break;
                case 3:
                    this._plane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
                    break;
                default:
                    throw new ArgumentException("Некорректная плоскость. Допустимые значения: 1, 2, 3.");
            }

            // Устанавливаем плоскость для эскиза
            sketch.SetPlane(this._plane);

            // Создаем эскиз
            this._sketch.Create();

            // Выходим из режима редактирования
            ksDocument2D sketchEdit = (ksDocument2D)sketch.BeginEdit();
            sketch.EndEdit();
        }

        /// <summary>
        /// Создание эскиза (скетча) на созданной плоскости.
        /// </summary>
        /// <exception cref="Exception">Ошибка инициализации</exception>
        /// <exception cref="ArgumentNullException">Ошибка значения NULL</exception>
        public void CreateSketch()
        {
            if (this._part == null)
            {
                throw new Exception("Деталь (_part) не была инициализирована. " +
                    "Вызовите CreateFile() перед созданием эскиза.");
            }

            if (_plane == null)
            {
                throw new ArgumentNullException(nameof(_plane), "Плоскость не должна быть null.");
            }

            ksSketchDefinition sketch;
            this._sketch = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_sketch);
            sketch = (ksSketchDefinition)this._sketch.GetDefinition();

            // Устанавливаем пользовательскую плоскость для эскиза
            sketch.SetPlane(_plane);

            // Создаем эскиз
            this._sketch.Create();

            // Выходим из режима редактирования
            ksDocument2D sketchEdit = (ksDocument2D)sketch.BeginEdit();
            sketch.EndEdit();
        }

        /// <summary>
        /// Создание линии в компасе.
        /// </summary>
        /// <param name="pointsArray">Массив точек по которым строятся линии.</param>
        /// <param name="start">Стартовый индекс массива.</param>
        /// <param name="count">Количество считываемых строк из массива.</param>
        public void CreateLine(double[,] pointsArray, int start, int count)
        {
            ksDocument2D document2D;
            ksSketchDefinition sketch;

            sketch = (ksSketchDefinition)this._sketch.GetDefinition();
            document2D = (ksDocument2D)sketch.BeginEdit();

            // Чертим линию
            if (document2D != null)
            {
                for (int i = start; i < start + count; i++)
                {
                    document2D.ksLineSeg(pointsArray[i, 0], pointsArray[i, 1], pointsArray[i, 2],
                        pointsArray[i, 3], (int)pointsArray[i, 4]);
                }

                sketch.EndEdit();
            }
        }

        /// <summary>
        /// Создание окружности.
        /// </summary>
        /// <param name="x1">X-координата первой окружности</param>
        /// <param name="y1">Y-координата первой окружности</param>
        /// <param name="x2">X-координата второй окружности</param>
        /// <param name="y2">Y-координата второй окружности</param>
        /// <param name="angleInDegrees">Угол в градусах</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateArc(double x1, double y1, double x2, double y2, int angleInDegrees)
        {
            ksDocument2D document2D;
            ksSketchDefinition sketch;
            sketch = (ksSketchDefinition)this._sketch.GetDefinition();
            document2D = (ksDocument2D)sketch.BeginEdit();

            if (document2D == null) throw new ArgumentNullException(nameof(document2D));

            double angleInRadians = angleInDegrees * Math.PI / 180.0;

            // Вычисление координат центра окружности
            double dx = x2 - x1;
            double dy = y2 - y1;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            double radius = dist / (2 * Math.Sin(angleInRadians / 2));
            double midX = (x1 + x2) / 2;
            double midY = (y1 + y2) / 2;

            // Смещение от середины отрезка к центру дуги
            double offset = Math.Sqrt(radius * radius - (dist / 2) * (dist / 2));
            double centerX = midX - dy / dist * offset;
            double centerY = midY + dx / dist * offset;

            // Построение дуги
            short direction = 1; // 1 - против часовой, -1 - по часовой стрелке
            document2D.ksArcByPoint(centerX, centerY, radius, x1, y1, x2, y2, direction, 1);
            sketch.EndEdit();
        }

        /// <summary>
        /// Задание вращения в компасе.
        /// </summary>
        public void Spin()
        {
            ksEntity entityRotate = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_bossRotated);
            if (entityRotate == null)
            {
                throw new Exception("Не удалось создать сущность для вращения.");
            }

            ksBossRotatedDefinition rotateDef = (ksBossRotatedDefinition)entityRotate.GetDefinition();
            if (rotateDef == null)
            {
                throw new Exception("Не удалось получить параметры для операции вращения.");
            }

            // Настраиваем параметры вращения
            rotateDef.directionType = (short)Direction_Type.dtNormal;
            rotateDef.SetSideParam(false, 360);
            rotateDef.SetSketch(this._sketch);

            // Создаем операцию вращения
            entityRotate.Create();
        }


        /// <summary>
        /// Выдавливание в компасе.
        /// </summary>
        /// <param name="parameter">Метод выдавливания.</param>
        /// <param name="length">Глубина выдавливания.</param>
        public void Extrusion(int parameter, double length)
        {
            ksEntity entityExtrusion = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_bossExtrusion);

            if (entityExtrusion == null)
            {
                throw new Exception("Не удалось создать сущность для выдавливания.");
            }

            // Получаем интерфейс свойств базовой операции выдавливания
            ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
            if (extrusionDef == null)
            {
                throw new Exception("Не удалось получить параметры выдавливания.");
            }

            // Тип выдавливания: 1 - стандартное, 2 - по траектороии
            switch (parameter)
            {
                case 1:
                    extrusionDef.directionType = (short)Direction_Type.dtMiddlePlane;
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, length, 0, false);
                    extrusionDef.SetThinParam(true, (short)Direction_Type.dtBoth, 2, 0);
                    extrusionDef.SetSketch(this._sketch);
                    entityExtrusion.Create();
                    break;

                case 2:
                    ksExtrusionParam extrusionProp = (ksExtrusionParam)extrusionDef.ExtrusionParam();
                    ksThinParam thinProp = (ksThinParam)extrusionDef.ThinParam();

                    if (extrusionProp == null || thinProp == null)
                    {
                        throw new Exception("Не удалось получить параметры выдавливания по траектории.");
                    }

                    extrusionDef.SetSketch(this._sketch);

                    extrusionProp.direction = (short)Direction_Type.dtNormal;
                    extrusionProp.typeNormal = (short)End_Type.etBlind;
                    extrusionProp.depthNormal = length;

                    thinProp.thin = false;

                    entityExtrusion.Create();
                    break;

                default:
                    throw new ArgumentException("Некорректный метод выдавливания. " +
                        "Допустимые значения: 1 (стандартное), 2 (по траектории).");
            }
        }


        /// <summary>
        /// Создание смещенной плоскости.
        /// </summary>
        /// <param name="basePlaneType">Тип базовой плоскости (1 - XOY, 2 - XOZ, 3 - YOZ).</param>
        /// <param name="offset">Смещение в мм от базовой плоскости.</param>
        public void CreateOffsetPlane(int basePlaneType, double offset)
        {
            if (this._part == null)
            {
                throw new Exception("Деталь (_part) не была инициализирована. " +
                    "Вызовите CreateFile() перед созданием смещенной плоскости.");
            }

            // Создаем базовую плоскость
            ksEntity basePlane;

            switch (basePlaneType)
            {
                case 1:
                    basePlane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                    break;
                case 2:
                    basePlane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                    break;
                case 3:
                    basePlane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
                    break;
                default:
                    throw new ArgumentException("Некорректный тип базовой плоскости. Допустимые значения: 1, 2, 3.");
            }

            if (basePlane == null)
            {
                throw new Exception("Не удалось получить базовую плоскость.");
            }

            // Создаем смещенную плоскость
            ksEntity offsetPlaneEntity = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_planeOffset);
            if (offsetPlaneEntity == null)
            {
                throw new Exception("Не удалось создать смещенную плоскость.");
            }

            // Получаем параметры смещенной плоскости
            ksPlaneOffsetDefinition offsetPlaneDef = (ksPlaneOffsetDefinition)offsetPlaneEntity.GetDefinition();
            if (offsetPlaneDef == null)
            {
                throw new Exception("Не удалось получить параметры смещенной плоскости.");
            }

            // Направление смещения (true/false)
            offsetPlaneDef.direction = true;
            
            // Устанавливаем смещение на значение "offset"
            offsetPlaneDef.offset = offset;

            // Устанавливаем базовую плоскость
            offsetPlaneDef.SetPlane(basePlane);

            // Создаем смещенную плоскость
            offsetPlaneEntity.Create();

            // Сохраняем смещенную плоскость
            this._plane = offsetPlaneEntity;
        }

        /// <summary>
        /// Создание окружности в эскизе.
        /// </summary>
        /// <param name="x">Координата центра X.</param>
        /// <param name="y">Координата центра Y.</param>
        /// <param name="radius">Радиус окружности.</param>
        public void CreateCircle(double radius, double x, double y)
        {
            ksDocument2D document2D;
            ksSketchDefinition sketchDef;

            sketchDef = (ksSketchDefinition)this._sketch.GetDefinition();
            document2D = (ksDocument2D)sketchDef.BeginEdit();

            // Создаем круг по координатам центра (x;y), радиусу и стилю
            if (document2D != null)
            {
                document2D.ksCircle(x, y, radius, 1);
            }

            // Заканчиваем скетч
            sketchDef.EndEdit();
        }

        /// <summary>
        /// Выдавливание объекта по сечениям.
        /// </summary>
        /// <param name="height">Высота чайника</param>
        /// <param name="bottom">Диаметр дна</param>
        /// <param name="lid">Диаметр крышки</param>
        /// <param name="handle">Высота ручки</param>
        /// <exception cref="Exception"></exception>
        public void CreateLoftedElement(double height, double bottom, double lid, double handle)
        {
            if (this._part == null)
            {
                throw new Exception("Деталь (_part) не была инициализирована. " +
                    "Вызовите CreateFile() перед созданием элемента.");
            }

            // Первый и второй объекты сечения
            ksEntity section1;
            ksEntity section2;

            // Направляющая кривая
            ksEntity guideCurve;

            // Задаем соотношение радиусов от создаваемого объема (15/13 - коэффициенты соотношения)
            double radius1 = bottom / 15 + height / 13;
            double radius2 = radius1 / 2;

            // Создаем окружность для первого сечения
            this.CreateSketch(3);
            if (this._sketch == null)
            {
                throw new Exception("Не удалось создать эскиз для первого сечения.");
            }
            section1 = this._sketch;
            this.CreateCircle(radius1, 0, (height / 11));

            // Создаем окружность для второго сечения
            this.CreateOffsetPlane(2, height / 2 + 2.5);
            this.CreateSketch();
            if (this._sketch == null)
            {
                throw new Exception("Не удалось создать эскиз для второго сечения.");
            }
            section2 = this._sketch;
            this.CreateCircle(radius2, -bottom * 1.15, 0);

            // Смещение дуги
            double offsetXCurve = -bottom * 1.2;
            double offsetYCurve = -(height / 4);

            // Высота начала дуги
            double heightCurve = height / 2 + 2.5;

            // Угол кривой
            int angle = 120;

            // Изменение угла по коэффициенту
            if (height / bottom <= 0.656)
            {
                angle = 50;
            }

            // Создаем направляющую кривую дугу
            this.CreateSketch(1);
            if (this._sketch == null)
            {
                throw new Exception("Не удалось создать эскиз для направляющей кривой.");
            }
            guideCurve = this._sketch;
            this.CreateArc(offsetXCurve, heightCurve, 0, offsetYCurve, angle);

            // Создаем сущность элемента по сечениям
            ksEntity loftEntity = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_bossLoft);
            if (loftEntity == null)
            {
                throw new Exception("Не удалось создать сущность элемента по сечениям.");
            }

            // Получаем параметры элемента
            ksBossLoftDefinition loftDef = (ksBossLoftDefinition)loftEntity.GetDefinition();
            if (loftDef == null)
            {
                throw new Exception("Не удалось получить параметры элемента по сечениям.");
            }

            // Настраиваем параметры сечений
            ksEntityCollection sections = (ksEntityCollection)loftDef.Sketchs();
            if (sections == null)
            {
                throw new Exception("Не удалось получить коллекцию сечений.");
            }

            // Добавляем сечения в коллекцию
            sections.Add(section1);
            sections.Add(section2);

            // Настраиваем направляющую кривую
            loftDef.SetDirectionalLine(guideCurve);

            // Устанавливаем параметры тонкостенного элемента (толщину стенок)
            double thickness = 0.4;
            loftDef.SetThinParam(true, 0, thickness, thickness);

            // Создаем элемент
            if (!loftEntity.Create())
            {
                throw new Exception("Не удалось создать элемент по сечениям.");
            }

            Console.WriteLine("Элемент по сечениям создан успешно.");
        }

        /// <summary>
        /// Изменение цвета всей модели.
        /// </summary>
        /// <param name="color">Цвет модели в формате int (например, 0xRRGGBB).</param>
        public void SetModelColor(int color)
        {
            if (_part == null)
            {
                throw new Exception("Деталь (_part) не была инициализирована. " +
                    "Вызовите CreateFile() перед изменением цвета.");
            }

            // Преобразуем заданный цвет из RRGGBB в BGR (цветовое пространство для OpenCV)
            int reversedColor = ((color & 0xFF) << 16) | (color & 0xFF00) | ((color >> 16) & 0xFF);

            // Задаем уровень окружающего и рассеянного света
            double _ambient = 1;
            double _diffuse = 1;

            // Устанавливаем цвет модели с расширенными параметрами
            bool result = this._part.SetAdvancedColor(reversedColor, 
                ambient: _ambient, diffuse: _diffuse);
            if (!result)
            {
                throw new Exception("Не удалось установить цвет для модели.");
            }

            // Обновляем деталь
            _part.Update();
        }
    }

}