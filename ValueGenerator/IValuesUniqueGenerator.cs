using System;
using System.Collections.Generic;
using System.Text;

namespace ValueGenerator
{
	/// <summary>
	/// Генератор уникальных значений
	/// </summary>
	/// <typeparam name="T">Тип генерируемого значения</typeparam>
	interface IValuesUniqueGenerator<T>
	{
		/// <summary>
		/// Перезапустить генератор
		/// </summary>
		void Reset();

		/// <summary>
		/// Генерировать значение
		/// </summary>
		/// <returns>Новое значение</returns>
		T GenerateUnique();

		/// <summary>
		/// Генерировать набор уникальных значений
		/// </summary>
		/// <param name="count">Количество генерируемых значений</param>
		/// <returns>Коллекция сгенерированых значений</returns>
		IEnumerable<T> GenerateUnique(int count)
		{
			for (int i = 0; i < count; i++)
			{
				yield return GenerateUnique();
			}
		}
	}
}
