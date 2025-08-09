@echo off
echo BUILD Cadmus NdpBooks Packages
del .\Cadmus.NdpBooks.Parts\bin\Debug\*.snupkg
del .\Cadmus.NdpBooks.Parts\bin\Debug\*.nupkg

del .\Cadmus.NdpBooks.Services\bin\Debug\*.snupkg
del .\Cadmus.NdpBooks.Services\bin\Debug\*.nupkg

del .\Cadmus.Seed.NdpBooks.Parts\bin\Debug\*.snupkg
del .\Cadmus.Seed.NdpBooks.Parts\bin\Debug\*.nupkg

cd .\Cadmus.NdpBooks.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.NdpBooks.Services
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.NdpBooks.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
