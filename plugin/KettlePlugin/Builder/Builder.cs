using Kompas;
using System;

namespace KettlePlugin
{
    /// <summary>
    /// Класс, отвечающий за построение модели с использованием API Kompas (Wrapper).
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Экземпляр класс Wrapper.
        /// </summary>
        private Wrapper _wrapper = new Wrapper();

        /// <summary>
        /// Новый экземпляр класса <see cref="Builder"/>.
        /// </summary>
        public Builder()
        {
            _wrapper = new Wrapper();
        }

        /// <summary>
        /// Построение модели с заданными параметрами.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="color"></param>
        public void Build(Parameters parameters, int color, int handleForm)
        {
            // Открываем CAD и создаём новый файл
            _wrapper.OpenCAD();
            _wrapper.CreateFile();

            // Вызываем основные методы для построения чайника
            BuildBase(parameters);
            BuildHandle(parameters, handleForm);
            BuildLid(parameters);
            BuildSpout(parameters);

            // Устанавливаем цвет чайника
            _wrapper.SetModelColor(color);
        }

        /// <summary>
        /// Метод для построения основания чайника.
        /// </summary>
        /// <param name="parameters">Параметры конструкции</param>
        private void BuildBase(Parameters parameters)
        {
            // Получаем параметры: высота и диаметры основания и крышки
            double height = parameters.AllParameters[ParameterType.HeightBase].Value;
            double bottom = parameters.AllParameters[ParameterType.DiameterBottom].Value;
            double lid = parameters.AllParameters[ParameterType.DiameterLid].Value;

            // Задаем параметры для отверстия
            double offsetHole = 1;
            double heightHole = offsetHole + 1.4;

            // Массив точек (делим размеры на 2, так как отсчет идет от 0;0)
            double[,] pointsArray = {
                // Линия дна
                { 0, -height / 2, -bottom / 2, -height / 2, 1 },
                // Вертикальная линия
                { -bottom / 2, -height / 2, -bottom / 2, height / 2, 1 },
                // Переход к отверстию
                { -bottom / 2 + offsetHole, height / 2 + offsetHole, -lid / 2 - offsetHole, height / 2 + offsetHole, 1 }, 
                // Поднятие отверстия
                { -lid / 2, height / 2 + 2, -lid / 2, height / 2 + heightHole, 1 }, 
                // Стенки отверстия
                { -lid / 2, height / 2 + heightHole, 0, height / 2 + heightHole, 1 }, 
                // Вспомогательная линия (3 в конце) вдоль оси OY
                { 0, -height / 2, 0, height / 2 + heightHole, 3 } 
            };

            // Создание эскиза и линий на плоскости
            _wrapper.CreateSketch(1); 
            _wrapper.CreateLine(pointsArray, 0, pointsArray.GetLength(0));

            // Добавляем 2 скругления дугами между линий 2/3 и 3/4
            _wrapper.CreateArc(-bottom / 2 + offsetHole, height / 2 + offsetHole, -bottom / 2, height / 2, 90);
            _wrapper.CreateArc(-lid / 2 - offsetHole, height / 2 + offsetHole, -lid / 2, height / 2 + 2, 90);

            // Выдавливание вращением
            _wrapper.Spin();
        }

        /// <summary>
        /// Построение ручки чайника, с возможностью смены формы.
        /// </summary>
        /// <param name="parameters">Параметры модели.</param>
        private void BuildHandle(Parameters parameters, int handleForm)
        {
            // Получаем параметры: высота, диаметр, диаметр крышки, высота ручки
            double height = parameters.AllParameters[ParameterType.HeightBase].Value;
            double bottom = parameters.AllParameters[ParameterType.DiameterBottom].Value;
            double lid = parameters.AllParameters[ParameterType.DiameterLid].Value;
            double handle = parameters.AllParameters[ParameterType.HeightHandle].Value;

            // Задаем параметр смещения для ручки
            double offsetHandle = 4.5;

            // Высчитываем среднее значение длины между дном и крышкой
            double xC = (-bottom / 2 - lid / 2) / 2;

            // Точки для высоты ручки
            double[,] pointsArray = {
                {xC, height/2, xC, height/2+handle-4.5, 1 }, // Высота ручки
                {-xC, height/2+handle-4.5, -xC, height/2, 1 }, // Вторая высота ручки
            };

            // Создаем скетч и строим заданные линии
            _wrapper.CreateSketch(1);
            _wrapper.CreateLine(pointsArray, 0, pointsArray.GetLength(0));

            switch (handleForm)
            {
                case 0: // Прямая ручка
                    //Создаем прямую линию ручки
                    double[,] horizontalPoint = {{xC + offsetHandle, height / 2 + handle, 
                        -xC - offsetHandle, height / 2 + handle, 1 }};
                    _wrapper.CreateLine(horizontalPoint, 0, 1);

                    // Создаем скругления дугами
                    _wrapper.CreateArc(xC + offsetHandle, height / 2 + handle, 
                        xC, height / 2 + handle - offsetHandle, 90);
                    _wrapper.CreateArc(-xC, height / 2 + handle - offsetHandle, 
                        -xC - offsetHandle, height / 2 + handle, 90);

                    break;

                case 1: // Изогнутая ручка (вниз)
                    // Создаем волнистую форму ручки
                    _wrapper.CreateArc(xC + lid / (offsetHandle - 0.5), height / 2 + handle - offsetHandle, 
                        xC, height / 2 + handle - offsetHandle, 90);
                    _wrapper.CreateArc(-xC, height / 2 + handle - offsetHandle, 
                        -xC - lid / (offsetHandle - 0.5), height / 2 + handle - offsetHandle, 90);
                    _wrapper.CreateArc(xC + lid / (offsetHandle - 0.5), height / 2 + handle - offsetHandle, 
                        -xC - lid / (offsetHandle - 0.5), height / 2 + handle - offsetHandle, 90);

                    break;

                case 2: // Изогнутая ручка (вверх)
                    // Создаем скругления дугами
                    _wrapper.CreateArc(xC + offsetHandle, height / 2 + handle,
                        xC, height / 2 + handle - offsetHandle, 90);
                    _wrapper.CreateArc(-xC, height / 2 + handle - offsetHandle, 
                        -xC - offsetHandle, height / 2 + handle, 90);

                    // Создаем волнистую форму ручки
                    _wrapper.CreateArc(xC + offsetHandle, height / 2 + handle, 
                        xC + lid / (offsetHandle - 0.5), height / 2 + handle + offsetHandle * 2,  90);
                    _wrapper.CreateArc(-xC - lid / (offsetHandle - 0.5), height / 2 + handle + offsetHandle * 2, 
                        xC + lid / (offsetHandle - 0.5), height / 2 + handle + offsetHandle * 2, 90);
                    _wrapper.CreateArc(-xC - lid / (offsetHandle - 0.5), height / 2 + handle + offsetHandle * 2, 
                        -xC - offsetHandle, height / 2 + handle, 90);

                    break;

                default:
                    throw new ArgumentException("Недопустимая форма ручки.");
            }

            int lenghtHandle = 14;

            //Выдавливаем ручку (тип выдавливания, длина ручки)
            _wrapper.Extrusion(1, lenghtHandle);
        }
        
        /// <summary>
        /// Построение крышки чайника.
        /// </summary>
        /// <param name="parameters">Параметры модели.</param>
        private void BuildLid(Parameters parameters)
        {
            // Получаем параметры: диаметр крышки, высота чайника
            double lid = parameters.AllParameters[ParameterType.DiameterLid].Value;
            double height = parameters.AllParameters[ParameterType.HeightBase].Value;

            // Задаем параметр смещения для плоскости
            double offset = 2.5;

            // Создаем плоскость по смещению
            _wrapper.CreateOffsetPlane(2, height / 2 + offset);
            _wrapper.CreateSketch();

            // Создаем окружность на плоскости
            _wrapper.CreateCircle(lid / 2 + 1, 0, 0);
            _wrapper.Extrusion(2, 2);

            // Создаем скетч на плоскости
            _wrapper.CreateSketch(1);

            // Высчитываем центр окружности
            double xC = (-lid / 2) / 2;

            // Создаем массив точек
            double[,] pointsArray = {
                // Высота ручки
                {xC, height / 2 + 4.5, xC, height / 2 + 10.5, 1 },
                // Держательная часть
                {xC + 2, height/2 + 12.5, -xC - 2, height / 2 + 12.5, 1 },
                // Вторая высота ручки
                {-xC, height / 2 + 4.5, -xC, height / 2 + 10.5, 1 },
            };

            // Создаем стороны линиями
            _wrapper.CreateLine(pointsArray, 0, pointsArray.GetLength(0));

            // Создаем скругления дугами
            _wrapper.CreateArc(xC + 2, height / 2 + 12.5, xC, height / 2 + 10.5, 90);
            _wrapper.CreateArc(-xC, height / 2 + 10.5, -xC - 2, height / 2 + 12.5, 90);

            // Задаем параметр длины для выдавливания
            int lenght = 7;

            // Выдавливаем
            _wrapper.Extrusion(1, lenght);
        }

        /// <summary>
        /// Построение носика чайника.
        /// </summary>
        /// <param name="parameters">Параметры модели.</param>
        private void BuildSpout(Parameters parameters)
        {
            // Получаем параметры: высота, диаметр, диаметр крышки, высота ручки
            double height = parameters.AllParameters[ParameterType.HeightBase].Value;
            double diameter = parameters.AllParameters[ParameterType.DiameterBottom].Value;
            double lid = parameters.AllParameters[ParameterType.DiameterLid].Value;
            double handle = parameters.AllParameters[ParameterType.HeightHandle].Value;

            // Создание скетчей и выдавливание по секциям
            _wrapper.CreateLoftedElement(height, diameter, lid, handle);
        }
    }
}