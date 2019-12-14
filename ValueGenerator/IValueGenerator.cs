using System;
using System.Collections.Generic;
using System.Text;

namespace ValueGenerator
{
	/// <summary>
	/// Генератор значений
	/// </summary>
	/// <typeparam name="T">Тип генерируемого значения</typeparam>
	public interface IValueGenerator<T>
	{
		/// <summary>
		/// Сгенерировать новое значение
		/// </summary>
		/// <returns>Новое значение</returns>
		T Generate();

		/// <summary>
		/// Сгенерировать набор значений
		/// </summary>
		/// <param name="count">Количество необходимых значений</param>
		/// <returns>Коллекция значений</returns>
		IEnumerable<T> Generate(int count)
		{
			for (int i = 0; i < count; i++)
			{
				yield return Generate();
			}
		}
	}
}
