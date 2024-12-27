using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using stdole;

namespace Kompas
{
    public class Wrapper
    {
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
        private Kompas6API5.ksEntity _sketchEntity;

        /// <summary>
        /// Поле для хранения выбранной плоскости.
        /// </summary>
        private Kompas6API5.ksEntity _plane;



        /// <summary>
        /// Создание документа в компасе.
        /// </summary>
        public void CreateFile()
        {
            ksDocument3D document3D;
            document3D = (ksDocument3D)this._kompas.Document3D();
            document3D.Create();
            this._part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Открытие компаса.
        /// </summary>
        public void OpenCAD()
        {
            try
            {
                // Попытка подключения к уже запущенному процессу Kompas3D
                this._kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                Console.WriteLine("Подключено к запущенному экземпляру Kompas3D.");
            }
            catch
            {
                // Если процесс не найден, создается новый экземпляр
                Type kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                if (kompasType != null)
                {
                    this._kompas = (KompasObject)Activator.CreateInstance(kompasType);
                    Console.WriteLine("Запущен новый экземпляр Kompas3D.");
                }
                else
                {
                    Console.WriteLine("Ошибка: Не удалось найти тип Kompas3D.");
                }
            }

            if (this._kompas != null)
            {
                this._kompas.Visible = true;
                this._kompas.ActivateControllerAPI();
                Console.WriteLine("Kompas3D готов к работе.");
            }
            else
            {
                throw new Exception("Не удалось запустить или подключиться к Kompas3D.");
            }
        }

        /// <summary>
        /// Создание эскиза в компасе.
        /// </summary>
        /// <param name="plane">Выбранная плоскость.</param>

        public void CreateSketch(int plane)
        {
            if (this._part == null)
            {
                throw new Exception("Деталь (_part) не была инициализирована. Вызовите CreateFile() перед созданием эскиза.");
            }

            ksSketchDefinition sketchDef;
            this._sketchEntity = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_sketch);
            sketchDef = (ksSketchDefinition)this._sketchEntity.GetDefinition();

            // Выбираем плоскость
            if (plane == 1)
            {
                this._plane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            }
            else if (plane == 2)
            {
                this._plane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            }
            else if (plane == 3)
            {
                this._plane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            }
            else
            {
                throw new ArgumentException("Некорректная плоскость. Допустимые значения: 1, 2, 3.");
            }

            // Устанавливаем плоскость для эскиза
            sketchDef.SetPlane(this._plane);

            // Создаем эскиз
            this._sketchEntity.Create();

            // Выходим из режима редактирования
            ksDocument2D sketchEdit = (ksDocument2D)sketchDef.BeginEdit();
            sketchDef.EndEdit();
        }

        /// <summary>
        /// Создание скетча на созданной плоскости.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateSketch()
        {
            if (this._part == null)
            {
                throw new Exception("Деталь (_part) не была инициализирована. Вызовите CreateFile() перед созданием эскиза.");
            }

            if (_plane == null)
            {
                throw new ArgumentNullException(nameof(_plane), "Плоскость не должна быть null.");
            }

            ksSketchDefinition sketchDef;
            this._sketchEntity = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_sketch);
            sketchDef = (ksSketchDefinition)this._sketchEntity.GetDefinition();

            // Устанавливаем пользовательскую плоскость для эскиза
            sketchDef.SetPlane(_plane);

            // Создаем эскиз
            this._sketchEntity.Create();

            // Выходим из режима редактирования
            ksDocument2D sketchEdit = (ksDocument2D)sketchDef.BeginEdit();
            sketchDef.EndEdit();
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
            ksSketchDefinition sketchDef;
            sketchDef = (ksSketchDefinition)this._sketchEntity.GetDefinition();
            document2D = (ksDocument2D)sketchDef.BeginEdit();
            if (document2D != null)
            {
                for (int i = start; i < start + count; i++)
                {
                    document2D.ksLineSeg(
                        pointsArray[i, 0],
                        pointsArray[i, 1],
                        pointsArray[i, 2],
                        pointsArray[i, 3],
                        (int)pointsArray[i, 4]);
                }

                sketchDef.EndEdit();
            }
        }

        /// <summary>
        /// Создание окружности.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="angleInDegrees"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateArc(double x1, double y1, double x2, double y2, int angleInDegrees)
        {
            ksDocument2D document2D;
            ksSketchDefinition sketch;
            sketch = (ksSketchDefinition)this._sketchEntity.GetDefinition();
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
            if (entityRotate != null)
            {
                ksBossRotatedDefinition rotateDef =
                    (ksBossRotatedDefinition)entityRotate.GetDefinition();
                if (rotateDef != null)
                {
                    rotateDef.directionType = (short)Direction_Type.dtNormal;
                    rotateDef.SetSideParam(false, 360);
                    rotateDef.SetSketch(this._sketchEntity);  // эскиз операции вращения
                    entityRotate.Create();              // создать операцию
                }
            }
        }

        /// <summary>
        /// Выдавливание в компасе.
        /// </summary>
        /// <param name="parameter">Метод выдавливания.</param>
        /// <param name="length">Глубина выдавливания.</param>
        public void Extrusion(int parameter, double length)
        {
            if (parameter == 1)
            {
                ksEntity entityExtrusion =
                    (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                if (entityExtrusion != null)
                {
                    ksEntity entityCutExtrusion =
                        (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                    if (entityCutExtrusion != null)
                    {
                        ksCutExtrusionDefinition cutExtrusionDef =
                            (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
                        if (cutExtrusionDef != null)
                        {
                            cutExtrusionDef.SetSketch(this._sketchEntity);
                            cutExtrusionDef.directionType = (short)Direction_Type.dtBoth;
                            cutExtrusionDef.SetSideParam(
                                true,
                                (short)End_Type.etBlind,
                                length,
                                0,
                                false);
                            cutExtrusionDef.SetThinParam(false, 0, 0, 0);
                        }

                        entityCutExtrusion.Create(); // создадим операцию вырезание выдавливанием
                    }
                }
            }
            else if (parameter == 2)
            {
                ksEntity entityExtrusion =
                    (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                if (entityExtrusion != null)
                {
                    // интерфейс свойств базовой операции выдавливания
                    ksBossExtrusionDefinition extrusionDef =
                        (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
                    if (extrusionDef != null)
                    {
                        extrusionDef.directionType = (short)Direction_Type.dtMiddlePlane;
                        extrusionDef.SetSideParam(
                            true, // прямое направление
                            (short)End_Type.etBlind,    // строго на глубину
                            length,
                            0,
                            false);
                        extrusionDef.SetThinParam(true, (short)Direction_Type.dtBoth, 2, 0);
                        extrusionDef.SetSketch(this._sketchEntity);   // эскиз операции выдавливания
                        entityExtrusion.Create();                    // создать операцию
                    }
                }
            }
            else if (parameter == 3)
            {
                ksEntity entityExtrusion =
                    (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                if (entityExtrusion != null)
                {
                    // интерфейс свойств базовой операции выдавливания
                    ksBossExtrusionDefinition extrusionDef =
                        (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
                    if (extrusionDef != null)
                    {
                        ksExtrusionParam extrusionProp =
                            (ksExtrusionParam)extrusionDef.ExtrusionParam();
                        ksThinParam thinProp = (ksThinParam)extrusionDef.ThinParam();
                        if (extrusionProp != null && thinProp != null)
                        {
                            extrusionDef.SetSketch(this._sketchEntity);

                            extrusionProp.direction = (short)Direction_Type.dtNormal;
                            extrusionProp.typeNormal = (short)End_Type.etBlind;
                            extrusionProp.depthNormal = length;

                            thinProp.thin = false;

                            entityExtrusion.Create();
                        }
                    }
                }
            }
            else if (parameter == 4) // 360-degree cut
            {
                ksEntity entityCutRotate = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_cutRotated);
                if (entityCutRotate != null)
                {
                    ksCutRotatedDefinition cutRotateDef = (ksCutRotatedDefinition)entityCutRotate.GetDefinition();
                    if (cutRotateDef != null)
                    {
                        cutRotateDef.directionType = (short)Direction_Type.dtNormal;
                        cutRotateDef.SetSideParam(false, 360); // Set full rotation
                        cutRotateDef.SetSketch(this._sketchEntity); // Link the sketch for rotation
                        entityCutRotate.Create(); // Create the cut operation
                    }
                }
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
                throw new Exception("Деталь (_part) не была инициализирована. Вызовите CreateFile() перед созданием смещенной плоскости.");
            }

            // Получаем базовую плоскость
            ksEntity basePlane = null;
            if (basePlaneType == 1)
            {
                basePlane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            }
            else if (basePlaneType == 2)
            {
                basePlane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            }
            else if (basePlaneType == 3)
            {
                basePlane = (ksEntity)this._part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            }
            else
            {
                throw new ArgumentException("Некорректный тип базовой плоскости. Допустимые значения: 1, 2, 3.");
            }

            if (basePlane == null)
            {
                throw new Exception("Не удалось получить базовую плоскость.");
            }

            // Создаем смещенную плоскость
            ksEntity offsetPlaneEntity = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_planeOffset);
            if (offsetPlaneEntity != null)
            {
                ksPlaneOffsetDefinition offsetPlaneDef = (ksPlaneOffsetDefinition)offsetPlaneEntity.GetDefinition();
                if (offsetPlaneDef != null)
                {
                    offsetPlaneDef.direction = true; // Направление смещения (true - положительное, false - отрицательное)
                    offsetPlaneDef.offset = offset; // Устанавливаем смещение
                    offsetPlaneDef.SetPlane(basePlane); // Устанавливаем базовую плоскость
                    offsetPlaneEntity.Create(); // Создаем смещенную плоскость

                    // Сохраняем ссылку на смещенную плоскость
                    this._plane = offsetPlaneEntity;
                    Console.WriteLine("Смещенная плоскость создана успешно.");
                }
                else
                {
                    throw new Exception("Не удалось получить параметры смещенной плоскости.");
                }
            }
            else
            {
                throw new Exception("Не удалось создать смещенную плоскость.");
            }
        }


        /// <summary>
        /// Рисует окружность в эскизе.
        /// </summary>
        /// <param name="x">Координата центра X.</param>
        /// <param name="y">Координата центра Y.</param>
        /// <param name="radius">Радиус окружности.</param>
        public void CreateCircle(double radius, double x, double y)
        {
            ksDocument2D document2D;
            ksSketchDefinition sketchDef;
            sketchDef = (ksSketchDefinition)this._sketchEntity.GetDefinition();
            document2D = (ksDocument2D)sketchDef.BeginEdit();
            if (document2D != null)
            {
                document2D.ksCircle(x, y, radius, 1);
            }
            sketchDef.EndEdit();
        }


        // FIX SMALL SPOUT PN BIG TEAPOAT
        /// <summary>
        /// Выдавливает объект по сечениям.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="diameter"></param>
        /// <param name="lid"></param>
        /// <param name="handle"></param>
        /// <exception cref="Exception"></exception>
        public void CreateLoftedElement(double height, double diameter, double lid, double handle)
        {
            if (this._part == null)
            {
                throw new Exception("Деталь (_part) не была инициализирована. Вызовите CreateFile() перед созданием элемента.");
            }

            ksEntity section1;
            ksEntity section2;
            ksEntity guideCurve;

            // Создаем первое сечение
            this.CreateSketch(3);
            if (this._sketchEntity == null)
            {
                throw new Exception("Не удалось создать эскиз для первого сечения.");
            }
            section1 = this._sketchEntity;
            this.CreateCircle(28, 0, -(height / 9));

            // Создаем второе сечение
            this.CreateOffsetPlane(2, height / 2 + 2.5);
            this.CreateSketch();
            if (this._sketchEntity == null)
            {
                throw new Exception("Не удалось создать эскиз для второго сечения.");
            }
            section2 = this._sketchEntity;
            this.CreateCircle(8, -diameter * 1.15, 0);

            // Создаем направляющую кривую
            this.CreateSketch(1);
            if (this._sketchEntity == null)
            {
                throw new Exception("Не удалось создать эскиз для направляющей кривой.");
            }
            guideCurve = this._sketchEntity;
            this.CreateArc(-diameter * 1.15, height / 2 + 2.5, 0, -(height / 10), 120);

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
            sections.Add(section1);
            sections.Add(section2);

            // Настраиваем направляющую кривую
            loftDef.SetDirectionalLine(guideCurve);

            // Устанавливаем параметры тонкостенного элемента
            loftDef.SetThinParam(true, 0, 0.4, 0.4);

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
                throw new Exception("Деталь (_part) не была инициализирована. Вызовите CreateFile() перед изменением цвета.");
            }
            // Преобразуем цвет из RRGGBB в BGR(если API требует обратного порядка)
            int reversedColor = ((color & 0xFF) << 16) | (color & 0xFF00) | ((color >> 16) & 0xFF);

            // Устанавливаем цвет модели с расширенными параметрами
            bool result = this._part.SetAdvancedColor(
                reversedColor,
                ambient: 1,        // Уровень окружающего света (от 0 до 1, больше для более яркого эффекта)
                diffuse: 1         // Уровень рассеянного света (от 0 до 1)
            );

            if (!result)
            {
                throw new Exception("Не удалось установить цвет для модели.");
            }

            _part.Update();
        }
    }

}