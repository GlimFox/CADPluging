using Kompas;

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
        public void Build(Parameters parameters, int color)
        {
            // Открываем CAD и создаём новый файл
            _wrapper.OpenCAD();
            _wrapper.CreateFile();

            BuildBase(parameters);
            BuildHandle(parameters);
            BuildLid(parameters);
            BuildSpout(parameters);
            _wrapper.SetModelColor(color);
        }

        /// <summary>
        /// Метод для построения сиденья табурета
        /// </summary>
        /// <param name="parameters">Параметры конструкции</param>
        private void BuildBase(Parameters parameters)
        {
            // Получаем параметры: высота и диаметр основания
            double height = parameters.AllParameters[ParameterType.HeightBase].Value;
            double diameter = parameters.AllParameters[ParameterType.DiameterBottom].Value;
            double lid = parameters.AllParameters[ParameterType.DiameterLid].Value;


            double[,] pointsArray = {
                { 0, -height/2, -diameter/2, -height/2, 1 }, // Дно
                { -diameter / 2, -height / 2, -diameter / 2, height / 2, 1 }, // Вертикальная линия
                { -diameter / 2 + 1, height / 2 + 1, -lid / 2 - 1, height / 2 + 1, 1 }, // Переход к отверстию
                { -lid / 2, height / 2 + 2, -lid / 2, height / 2 + 2.4, 1 }, // Чуть поднять отверстие
                { -lid / 2, height / 2 + 2.4, 0, height / 2 + 2.4, 1 }, // Стенки отверстия
                { 0, -height / 2, 0, height / 2 + 2.4, 3 } // Вспомогательная осевая линия
            };

            _wrapper.CreateSketch(1); // Создание эскиза на плоскости
            _wrapper.CreateLine(pointsArray, 0, pointsArray.GetLength(0)); // Рисуем стороны

            // Добавляем 2 скругления для линий 2/3 и 3/4
            _wrapper.CreateArc(-diameter / 2 + 1, height / 2 + 1, -diameter / 2, height / 2, 90);
            _wrapper.CreateArc(-lid / 2 - 1, height / 2 + 1, -lid / 2, height / 2 + 2, 90);

            _wrapper.Spin();
        }

        /// <summary>
        /// Построение ручки модели.
        /// </summary>
        /// <param name="parameters">Параметры модели.</param>
        private void BuildHandle(Parameters parameters)
        {
            // Получаем параметры: высота, диаметр, диаметр крышки, высота ручки
            double height = parameters.AllParameters[ParameterType.HeightBase].Value;
            double diameter = parameters.AllParameters[ParameterType.DiameterBottom].Value;
            double lid = parameters.AllParameters[ParameterType.DiameterLid].Value;
            double handle = parameters.AllParameters[ParameterType.HeightHandle].Value;

            // Высчитываем среднее значение между дном и крышкой
            double xC = (-diameter / 2 - lid / 2) / 2;

            // Массив точек
            double[,] pointsArray = {
                {xC, height/2, xC, height/2+handle-4.5, 1 }, // Высота ручки
                {xC+4.5, height/2+handle, -xC-4.5, height/2+handle, 1 }, // Держательная часть
                {-xC, height/2+handle-4.5, -xC, height/2, 1 }, // Вторая высота ручки
            };

            // Создаем скетч и строим заданные линии
            _wrapper.CreateSketch(1);
            _wrapper.CreateLine(pointsArray, 0, pointsArray.GetLength(0));

            // Создаем скругления дугами
            _wrapper.CreateArc(xC + 4.5, height / 2 + handle, xC, height / 2 + handle - 4.5, 90);
            _wrapper.CreateArc(-xC, height / 2 + handle - 4.5, -xC - 4.5, height / 2 + handle, 90);

            //Выдавливаем ручку
            _wrapper.Extrusion(2, 14);
        }

        /// <summary>
        /// Построение крышки модели.
        /// </summary>
        /// <param name="parameters">Параметры модели.</param>
        private void BuildLid(Parameters parameters)
        {
            double lid = parameters.AllParameters[ParameterType.DiameterLid].Value;
            double height = parameters.AllParameters[ParameterType.HeightBase].Value;

            _wrapper.CreateOffsetPlane(2, height / 2 + 2.5);
            _wrapper.CreateSketch();

            _wrapper.CreateCircle(lid / 2 + 1, 0, 0);
            _wrapper.Extrusion(3, 2);

            _wrapper.CreateSketch(1);

            double xC = (-lid / 2) / 2;
            double[,] pointsArray = {
                {xC, height/2+4.5, xC, height/2+10.5, 1 }, // Высота ручки
                {xC+2, height/2+12.5, -xC-2,  height/2+12.5, 1 }, // Держательная часть
                {-xC, height/2+4.5, -xC, height/2+10.5, 1 }, // Вторая высота ручки
            };
            _wrapper.CreateLine(pointsArray, 0, pointsArray.GetLength(0)); // Рисуем стороны

            _wrapper.CreateArc(xC + 2, height / 2 + 12.5, xC, height / 2 + 10.5, 90);
            _wrapper.CreateArc(-xC, height / 2 + 10.5, -xC - 2, height / 2 + 12.5, 90);

            _wrapper.Extrusion(2, 7);
        }

        /// <summary>
        /// Построение носика модели.
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