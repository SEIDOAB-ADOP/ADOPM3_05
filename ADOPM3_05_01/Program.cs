﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ADOPM3_05_01
{
 	public static class StringExtension
	{
		public static bool IsCapitalized(this string s)
		{
			if (string.IsNullOrEmpty(s)) return false;
			return char.IsUpper(s[0]);
		}
		public static string Capitalize(this string s)
		{
			if (string.IsNullOrEmpty(s)) return s;

			return char.ToUpper(s[0]) + s.Substring(1);
		}
	}

	public static class CharExtension
	{
		public static char ToUpper(this char c) => char.ToUpper(c); //Note the type extended is char
	}

	static class IEnumerableExtension
	{
		public static T First<T>(this IEnumerable<T> sequence)
		{
			foreach (T element in sequence)
				return element;
			throw new InvalidOperationException("No elements!");
		}

		public static IEnumerable<T> StripNulls<T>(this IEnumerable<T> seq)
		{
			foreach (T t in seq)
				if (t != null)
					yield return t;
		}
	}
	class Program
    {
		static void Main(string[] args)
        {
			Console.WriteLine(StringExtension.IsCapitalized("Perth"));  // Using it in a classic way

			Console.WriteLine("Perth".IsCapitalized()); // Using the Method as an extension

            Console.WriteLine("martin".Capitalize());
			
			Console.WriteLine("Seatle".First());   // S

			int[] list = { 1, 2, 3,};
			System.Console.WriteLine(list.First());
			


			//chain Extension Methods
			Console.WriteLine(IEnumerableExtension.First("stockholm").ToUpper()); //S

			Console.WriteLine("stockholm".First().ToUpper()); //S

			string[] strings = { "a", "b", null, "c" };
			foreach (string s in strings.StripNulls())
				Console.WriteLine(s);
			
		}
	}
	
	//Exercises:
	//1.	Modify First<T> to return First element using an Enumerator instead of foreach 
	//2.	Write an extension Method that extends IEnumerable<T> with a method that printout each element in a Generic Collection.
	//		Test it to printout each element in a Queue and Stack
}
