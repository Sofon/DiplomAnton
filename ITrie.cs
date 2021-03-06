﻿using System.Collections.Generic;

namespace rm.Trie
{
	/// <summary>
	/// Interface for Trie data structure.
	/// </summary>
	public interface ITrie
	{
		/// <summary>
		/// Add a word to the Trie.
		/// </summary>
		void AddWord(string word);

		/// <summary>
		/// Remove word from the Trie.
		/// </summary>
		/// <returns>Count of words removed.</returns>
		int RemoveWord(string word);

		/// <summary>
		/// Remove words by prefix from the Trie.
		/// </summary>
		void RemovePrefix(string prefix);

		/// <summary>
		/// Get all words in the Trie.
		/// </summary>
		ICollection<string> GetWords();

		/// <summary>
		/// Get words for given prefix.
		/// </summary>
		ICollection<string> GetWords(string prefix);

		/// <summary>
		/// Returns true or false if the word is present in the Trie.
		/// </summary>
		bool HasWord(string word);

		/// <summary>
		/// Returns the count for the word in the Trie.
		/// </summary>
		int WordCount(string word);

		/// <summary>
		/// Get longest words from the Trie.
		/// </summary>
		ICollection<string> GetLongestWords();

		/// <summary>
		/// Get shortest words from the Trie.
		/// </summary>
		ICollection<string> GetShortestWords();

		/// <summary>
		/// Clear all words from the Trie.
		/// </summary>
		void Clear();

		/// <summary>
		/// Get total word count in the Trie.
		/// </summary>
		int Count();

		/// <summary>
		/// Get unique word count in the Trie.
		/// </summary>
		int UniqueCount();
	}
}
