using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Book{

	public int width;
	public int height;

	public int actualPage;
	public string plainText;
	public List<string> pages;

	public Book(string _plainText){
		pages = new List<string>();
		plainText = _plainText;
		actualPage = 0;
		width = 15;
		height = 8;
		
	}


	public string ResolveTextSize(string input, int lineLength){

		int lineNumber = 1;
		 
		// Split string by char " "         
		string[] words = input.Split(" "[0]);
		
		// Prepare result
		string result = "";
		
		// Temp line string
		string line = "";
	
		// for each all words        
		foreach(string s in words){

			// Append current word into line
			string temp = line + " " + s;
		
			// If line length is bigger than lineLength
			if(temp.Length > lineLength){
				// Append current line into result
				result += line + "\n";
				lineNumber++;
				// Remain word append into new line
				line = s;
			} 
			// Append current word into current line
			else {
				line = temp;
			}
		}
	
		// Append last line into result        
		result += line;
		
	

		//Split to pages
		int lineCount = 1;
		string semafor = "";
		foreach(char s in result.Substring(1,result.Length-1)){
			semafor += s;
			if(s == '\n'){
				lineCount++;
			}
			if(lineCount % height == 0){
				pages.Add(semafor);
				semafor = "";
				lineCount = 1;
			}
		}


		// Remove first " " char
		return result.Substring(1,result.Length-1);
	}

	public void NextPage(){
		if(actualPage + 1 >= pages.Count){
			actualPage = 0;
		} else {
			actualPage++;
		}
	}

	public void PreviousPage(){
		if(actualPage - 1 < 0){
			actualPage = pages.Count - 1;
		} else {
			actualPage--;
		}
	}
}

public class PlayText : MonoBehaviour {

	public List<Book> allBooks;
	public int actualIndex;
	
	TextMesh actualText;
	void Start () {
		StartCoroutine (LoadBooks());
		actualIndex = 0;
		actualText = GetComponent<TextMesh>();
		allBooks = new List<Book>();
	}
	

	IEnumerator LoadBooks(){
		string[] paths = Directory.GetFiles (Application.streamingAssetsPath, "*.txt");

		for (int i = 0; i < paths.Length; i++) {
			WWW diskDirectory = new WWW ("file://" + paths[i]);
			while(!diskDirectory.isDone){
				yield return null;
			}
			string actualString = diskDirectory.text;
			Book temp = new Book(actualString);
			//temp.ResolveTextSize(actualString, temp.width);
			//temp.NextPage();
			
			//temp.name = Path.GetFileName(diskDirectory.url);
			allBooks.Add (temp);
			diskDirectory.Dispose();
		}
		for(int i = 0; i < allBooks.Count; i++){
			allBooks[i].ResolveTextSize(allBooks[i].plainText, allBooks[i].width);
		}
		TextSet(0);
	}

	public void TextSet(int index){
		actualIndex = index;
		Book temp = allBooks[index];
		actualText.text = temp.pages[temp.actualPage];
	}

	public void UpdateText(){
		Book temp = allBooks[actualIndex];
		actualText.text = temp.pages[temp.actualPage];
	}


	

}
