# HFind
This project clone the **"find"** command line feature. It includes functionalities to search for a string of text in a file or files, and displays lines of text that contain the specified string.


### Running the Project
1. Clone this repository.
2. Open the project in Visual Studio and build the solution.
3. Copy all files in the `Samples` folder and paste them into `HCommands\HFind\bin\Debug\net8.0`.

### Running from Command Line
1. Open the command line and navigate to the `HCommands\HFind\bin\Debug\net8.0` folder.
2. Execute the `hfind` command with the following syntax:
   ```bash
   hfind [/v] [/c] [/n] [/i]  <search_string> <file_path>
3. Example:
	```bash
	hfind /n France shakespeare-loves-8.txt
