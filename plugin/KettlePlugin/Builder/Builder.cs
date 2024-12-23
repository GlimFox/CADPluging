using System;
using System.Security.Cryptography;
using Kompas;
using System;
using System.Collections.Generic;
using KompasAPI7;
using Kompas;
using Kompas6Constants3D;
using Kompas6Constants;
using System.Security.Cryptography;
using Kompas6API5;
using Kompas6API3D5COM;
using Kompas6API2D5COM;
using KompasLibrary;
using static System.Net.Mime.MediaTypeNames;

namespace KettlePlugin
{
    public class Builder
    {
        /// <summary>
        /// Экземпляр класс Wrapper.
        /// </summary>
        private Wrapper _wrapper = new Wrapper();

        public Builder()
        {
            _wrapper = new Wrapper();
        }

        /// <summary>
        /// Метод для построения табурета с заданными параметрами, типом сиденья и ножек
        /// </summary>
        /// <param name="parameters">Параметры табурета</param>
        /// <param name="seatType">Тип сиденья</param>
        /// <param name="legType">Тип ножек</param>
        public void Build(Parameters parameters, int color)
        {
            _wrapper.OpenCAD();

            IPart7 part = _wrapper.CreatePart();
            BuildBase(part, parameters);
            //BuildButt(part, parameters);

        }

        /// <summary>
        /// Метод для построения сиденья табурета
        /// </summary>
        /// <param name="part">Часть топора, к которой добавляется обух </param>
        /// <param name="parameters">Параметры конструкции</param>

        private void BuildBase(IPart7 part, Parameters parameters)
        {
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part), "Часть не может быть null.");
            }

            // Получаем параметры: высота и диаметр основания
            double height = parameters.AllParameters[ParameterType.HeightBase].Value;
            double diameter = parameters.AllParameters[ParameterType.DiameterBottom].Value;
            double lid = parameters.AllParameters[ParameterType.DiameterLid].Value;

            var plane = _wrapper.GetSidePlane(part, ksObj3dTypeEnum.o3d_planeXOZ);
            ISketch sketch = this._wrapper.CreateSketchOnPlane(part, plane, "Основание чайника");

            // Создаем линии

            // 0 -height/2          -diameter/2 -height/2
            // -diameter/2 -height/2    -diameter/2 height/2-2.4
            // -diameter/2 height/2-2.4     -lid/2 height/2-1.4
            // -lid/2 height/2      0 height/2

            _wrapper.CreateLine(sketch, 0, -height/2, -diameter/2, -height/2); // Дно
            _wrapper.CreateLine(sketch, -diameter/2, -height/2, -diameter/2, height/2+1); // Вертикальная линия
            _wrapper.CreateLine(sketch, -diameter/2, height/2+1, -lid/2, height/2+1); // Под переход к стенке
            _wrapper.CreateLine(sketch, -lid/2, height/2+2.4, 0, height/2+2.4); // Под отверстие в чайнике
            
            

            // Добавляем скругления
            //sketchEditor.CreateFillet(line1, line2, 6); // Верхний левый угол
            //sketchEditor.CreateFillet(line3, line4, 12); // Нижний правый угол

            //sketchEditor.EndEdit();

            // Выполняем вращение профиля

        }


        //private void BuildButt(IPart7 part, Parameters parameters)
        //{
        //    if (parameters.AllParameters.TryGetValue(ParameterType.LenghtBlade, out Parameter LenghtBladeParameter))
        //    {
        //        double LenghtBladeValue = LenghtBladeParameter.Value;

        //        if (parameters.AllParameters.TryGetValue(ParameterType.WidthButt, out Parameter WidthButtParameter))
        //        {
        //            double WidthButtValue = WidthButtParameter.Value;

        //            if (parameters.AllParameters.TryGetValue(ParameterType.LenghtButt, out Parameter LenghtButtParameter))
        //            {
        //                double LenghtButtValue = LenghtButtParameter.Value;

        //                if (parameters.AllParameters.TryGetValue(ParameterType.ThicknessButt, out Parameter ThicknessButtParameter))
        //                {
        //                    double ThicknessButtValue = ThicknessButtParameter.Value;

        //                    if (parameters.AllParameters.TryGetValue(ParameterType.LengthHandle, out Parameter LengthHandleParameter))
        //                    {


        //                        // Создаем прямоугольник сверху обуха
        //                        ISketch topRectangleSketch = _wrapper.CreateSketch(part, "Эскиз: прямоугольник сверху обуха");

        //                        double rectangleWidth = WidthButtValue;       // Ширина прямоугольника
        //                        double rectangleHeight = ThicknessButtValue; // Высота прямоугольника

        //                        // Центрируем прямоугольник относительно оси Z
        //                        double xStart = -rectangleWidth / 2;
        //                        double yStart = -rectangleHeight / 2;

        //                        // Рисуем прямоугольник
        //                        _wrapper.CreateRectangle(topRectangleSketch, xStart, yStart, rectangleWidth, rectangleHeight);
        //                        //выдавливаем
        //                        _wrapper.ExtrudeSketch(topRectangleSketch, LenghtButtValue, "Прямоугольник на обухе", false);




        //                        // Параметры трапеции (равнобедренная)
        //                        double topBase = LenghtButtValue;    // Верхняя основа (меньшая сторона)
        //                        double bottomBase = LenghtBladeValue; // Нижняя основа (большая сторона)
        //                        double height = WidthButtValue;     // Высота трапеции

        //                        object sidePlane = _wrapper.GetSidePlane(part, Kompas6Constants3D.ksObj3dTypeEnum.o3d_planeXOZ);

        //                        // Создаем эскиз на боковой плоскости
        //                        ISketch trapezoidSketch = _wrapper.CreateSketchOnPlane(part, sidePlane, "Эскиз: равнобедренная трапеция");

        //                        // Смещение эскиза трапеции
        //                        double offsetX = -WidthButtValue / 2; // Смещение по оси X (конец прямоугольника)
        //                        double offsetY = -LenghtButtValue / 2; // Смещение по оси Y (центр прямоугольника)

        //                        // Координаты для равнобедренной трапеции (с учётом смещений)
        //                        double x1 = offsetX;                        // Левая вершина верхней основы
        //                        double y1 = offsetY - (topBase / 2);        // Верхняя основа центрирована по Y

        //                        double x2 = offsetX;                        // Правая вершина верхней основы
        //                        double y2 = offsetY + (topBase / 2);

        //                        double x3 = offsetX - height;               // Левая вершина нижней основы
        //                        double y3 = offsetY - (bottomBase / 2);     // Нижняя основа центрирована по Y

        //                        double x4 = offsetX - height;               // Правая вершина нижней основы
        //                        double y4 = offsetY + (bottomBase / 2);

        //                        // Рисуем трапецию
        //                        _wrapper.CreateLine(trapezoidSketch, x1, y1, x2, y2); // Верхняя основа
        //                        _wrapper.CreateLine(trapezoidSketch, x2, y2, x4, y4); // Правая боковая сторона
        //                        _wrapper.CreateLine(trapezoidSketch, x4, y4, x3, y3); // Нижняя основа
        //                        _wrapper.CreateLine(trapezoidSketch, x3, y3, x1, y1); // Левая боковая сторона

        //                        // Выдавливаем трапецию
        //                        _wrapper.ExtrudeSketch(trapezoidSketch, ThicknessButtValue / 2, "Равнобедренная трапеция на боковой плоскости", false);
        //                        _wrapper.ExtrudeSketch(trapezoidSketch, -ThicknessButtValue / 2, "Равнобедренная трапеция на боковой плоскости", false);



        //                        object sidePlane_1 = _wrapper.GetSidePlane(part, Kompas6Constants3D.ksObj3dTypeEnum.o3d_planeXOY);
        //                        // Создаем эскиз на боковой плоскости
        //                        ISketch triangleSketch = _wrapper.CreateSketchOnPlane(part, sidePlane_1, "Эскиз: Треугольник для выреза");

        //                        double x1_ = -LenghtButtValue / 2;
        //                        double y1_ = ThicknessButtValue / 2;

        //                        double x2_ = -LenghtButtValue * 1.5;
        //                        double y2_ = ThicknessButtValue / 2;

        //                        double x3_ = -LenghtButtValue * 1.5;
        //                        double y3_ = 0;

        //                        _wrapper.CreateLine(triangleSketch, x1_, y1_, x2_, y2_);
        //                        _wrapper.CreateLine(triangleSketch, x2_, y2_, x3_, y3_);
        //                        _wrapper.CreateLine(triangleSketch, x3_, y3_, x1_, y1_);

        //                        _wrapper.CutExtrudeSymmetric(triangleSketch, 250, "Симметричное вырезание");


        //                        // Создаем эскиз на боковой плоскости
        //                        ISketch triangleSketch_2 = _wrapper.CreateSketchOnPlane(part, sidePlane_1, "Эскиз: Треугольник для выреза");

        //                        double x1_1 = -LenghtButtValue / 2;
        //                        double y1_1 = -ThicknessButtValue / 2;

        //                        double x2_1 = -LenghtButtValue * 1.5;
        //                        double y2_1 = -ThicknessButtValue / 2;

        //                        double x3_1 = -LenghtButtValue * 1.5;
        //                        double y3_1 = 0;

        //                        _wrapper.CreateLine(triangleSketch_2, x1_1, y1_1, x2_1, y2_1);
        //                        _wrapper.CreateLine(triangleSketch_2, x2_1, y2_1, x3_1, y3_1);
        //                        _wrapper.CreateLine(triangleSketch_2, x3_1, y3_1, x1_1, y1_1);

        //                        _wrapper.CutExtrudeSymmetric(triangleSketch_2, 250, "Симметричное вырезание");

        //                    }
        //                }

        //            }


        //        }

        //    }

        //}
    }
}