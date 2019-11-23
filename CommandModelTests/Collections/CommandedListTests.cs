using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandModel.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using CommandModelTests;
using System.Linq;

namespace CommandModel.Collections.Tests
{
	[TestClass()]
	public class CommandedListTests
	{
		private const int RANDOM_KEY = 13;
		private const int TESTS_COUNT = 10;

		private class OffsetTokenDispatcher : IOffsetTokenDispatcher
		{
			public int CurrentToken { get; private set; } = 0;

			public IComparable CreateToken()
			{
				return CurrentToken++;
			}
		}

		private static CommandDispatcher CreateCommandDispatcher()
		{
			return new CommandDispatcher(new OffsetTokenDispatcher());
		}

		private static Int32Generator CreateCountGenerator(Random random)
		{
			const int MIN = 0;
			const int MAX = 100;
			return new Int32Generator(random, MIN, MAX);
		}

		private static List<T> CreateOriginalList<T>(IValueGenerator<int> countGenerator, IValueGenerator<T> valueGenerator)
		{
			var count = countGenerator.Generate();
			var result = new List<T>();
			for (int i = 0; i < count; i++)
			{
				result.Add(valueGenerator.Generate());
			}
			return result;
		}
		private static CommandedList<T> CreateTestListByOriginal<T>(List<T> list)
		{
			var result = new CommandedList<T>(CreateCommandDispatcher());
			foreach (var item in list)
			{
				result.Add(item);
			}
			return result;
		}

		[TestMethod()]
		public void IndexOfTest()
		{
			var random = new Random(RANDOM_KEY);
			IndexOfTest(TESTS_COUNT, CreateCountGenerator(random), new Int32Generator(random));
		}
		private void IndexOfTest<T>(int testsCount, IValueGenerator<int> countGenerator, IValueGenerator<T> valueGenerator)
		{
			for (int iTest = 0; iTest < testsCount; iTest++)
			{
				var originalList = CreateOriginalList(countGenerator, valueGenerator);
				var testList = CreateTestListByOriginal(originalList);

				foreach (var item in originalList)
				{
					Assert.IsTrue(testList.IndexOf(item) == originalList.IndexOf(item));
				}
			}
		}

		[TestMethod()]
		public void RemoveAtTest()
		{
			var random = new Random(RANDOM_KEY);
			RemoveAtTest(TESTS_COUNT, CreateCountGenerator(random), new Int32Generator(random), new Int32Generator(random));
		}
		private void RemoveAtTest<T>(int testsCount, IValueGenerator<int> countGenerator, IValueGenerator<T> valueGenerator, Int32Generator indexGenerator)
		{
			for (int iTest = 0; iTest < testsCount; iTest++)
			{
				var originalList = CreateOriginalList(countGenerator, valueGenerator);
				var testList = CreateTestListByOriginal(originalList);

				while (originalList.Any())
				{
					var index = indexGenerator.Generate(0, originalList.Count);
					originalList.RemoveAt(index);
					testList.RemoveAt(index);
					Assert.IsTrue(originalList.SequenceEqual(testList));
				}
			}
		}

		[TestMethod()]
		public void AddTest()
		{
			
		}

		[TestMethod()]
		public void ClearTest()
		{
			
		}

		[TestMethod()]
		public void ContainsTest()
		{
			
		}

		[TestMethod()]
		public void CopyToTest()
		{
			
		}

		[TestMethod()]
		public void RemoveTest()
		{
			
		}

		[TestMethod()]
		public void GetEnumeratorTest()
		{
			
		}
	}
}