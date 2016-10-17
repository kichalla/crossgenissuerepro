Repro:

1. Clone the repo
2. Run `dotnet restore`
3. cd to `src\CrossGenAndVersionMismatchRepro`
4. Run `dotnet publish -c Release -f netcoreapp10`
5. cd to `bin\Release\netcoreapp1.0\publish`
6. Run the powershell script `.\Invoke-Crossgen.ps1`
7. You should see an exception like the following:

Using crossgen.exe at .\.crossgen\crossgen.exe and shared framework at C:\Users\kichalla\AppData\Local\Microsoft\dotnet\shared\Microsoft.NETCore.App\1.1.0-preview1-001100-00
Running .\.crossgen\crossgen.exe /Platform_Assemblies_Paths "C:\Users\kichalla\AppData\Local\Microsoft\dotnet\shared\Microsoft.NETCore.App\1.1.0-preview1-001100-00" /App_Paths "C:\temp\crossgenissuerepro\src\CrossGenAndVersionMismatchRepro\bin\Release\netcoreapp1.0\publish" /out "C:\temp\crossgenissuerepro\src\CrossGenAndVersionMismatchRepro\bin\Release\netcoreapp1.0\publish\CrossGenAndVersionMismatchRepro.ni.dll" "C:\temp\crossgenissuerepro\src\CrossGenAndVersionMismatchRepro\bin\Release\netcoreapp1.0\publish\CrossGenAndVersionMismatchRepro.dll"
Microsoft (R) CoreCLR Native Image Generator - Version 4.5.22220.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Error: Could not load file or assembly 'System.Diagnostics.StackTrace, Version=4.0.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
Error compiling C:\temp\crossgenissuerepro\src\CrossGenAndVersionMismatchRepro\bin\Release\netcoreapp1.0\publish\CrossGenAndVersionMismatchRepro.dll: Could not find or load a specific file. (Exception from HRESULT: 0x80131621)
Error: compilation failed for "C:\temp\crossgenissuerepro\src\CrossGenAndVersionMismatchRepro\bin\Release\netcoreapp1.0\publish\CrossGenAndVersionMismatchRepro.dll" (0x80131621)



NOTE: System.Diagnostics.StackTrace has ref version of '4.0.2' but the implementation dll is '4.0.3'. It appears that this is just fine (i.e the implementation dlls must be >= the ref versions) and also the app runs fine. But the cross gen doesn't seem to consider this and throws the above exception. Probably a bug with cross gen.
