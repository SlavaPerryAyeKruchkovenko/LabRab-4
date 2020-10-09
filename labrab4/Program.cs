using System;
using System.Collections.Generic;

namespace labrab4
{
	class Program
	{
		static int Count(string text)
		{
			int longest=0;
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == ',')
					longest++;
			}
			return longest;
		}
		static bool FindUnic(List<string> words,string word)
		{
			int replay=0;
			for (int i = 0; i < words.Count; i++)
			{
				if(word==words[i])
				{
					replay++;
				}
			}
			if (replay > 1)
				return false;
			else
				return true;
		}
		static string SoLong(List<string> words)
		{
			int max = 0;
			string word="";
			for (int i = 0; i < words.Count; i++)
			{
				if(words[i].Length>max)
				{
					max = words[i].Length;
					word = words[i];
				}
			}
			return word;
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Введите текст");
			string text = Console.ReadLine(),max;			
			List<string> allWords = new List<string>();
			List<string> unicWords = new List<string>();
			string[] sentences,words;

			Console.WriteLine("Количесвто знаков");
			Console.WriteLine(Count(text) + text.Split(new char[] { '.', '!', '?', ';', ':', ')', '(', }).Length - 1);
		    sentences = text.Split(new char[] { '.', '!', '?', ';', ':', ')', '(', }, StringSplitOptions.RemoveEmptyEntries);
			
			for (int i = 0; i < sentences.Length; i++)
			{
				words = sentences[i].Split(' ', ',');
				for (int j = 0; j < words.Length; j++)
				{
					allWords.Add(words[j].ToString());					
				}
			}
			Console.WriteLine("уникальные слова");
			for (int i = 0; i < allWords.Count; i++)
			{
				if (FindUnic(allWords, allWords[i])&&allWords[i]!="")
				{
					unicWords.Add(allWords[i]);
					Console.WriteLine(allWords[i],',');
				}
					
			}
			if (unicWords.Count < 1)
				Console.WriteLine("Нету");

			Console.WriteLine("Самое длинное слово");

			max = SoLong(allWords);
			if (max.Length % 2 == 0)
				Console.WriteLine(max.Substring(max.Length / 2 ));
			else
			{
				max = max.Substring(0, (max.Length - 1) / 2) + '*' + max.Substring((max.Length) / 2+1);
				Console.WriteLine(max);
			}

			

		}
	}
}
