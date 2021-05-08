# Unique Four Letters Chunks Problem

## Problem statement : 
Given a file of words, create a the a sorted list of unique four letter chunks, and a save it in a file : `uniques.txt`. Also save the corresponding word where that chunk was found in another file : `fullwords.txt` 

Input : ``input/words.txt``  
Output : Unique four letter chunks sorted - ``output/uniques.txt``
         Corresponding source words - ``output/fullwords.txt``


## Installation
```bash
cd UniqueFourLetters.Console
dotnet run 
```
The solution has been configured to create files in a new `output` folder 
Also added a stopwatch to check runtime of the solution


## Tests

On the root folder run : 
```bash
dotnet test 
```

Unit Tests Folder : UniqueFourLetters.Tests
