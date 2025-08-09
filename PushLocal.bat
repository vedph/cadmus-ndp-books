@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.NdpBooks.Parts\bin\Debug\Cadmus.NdpBooks.Parts.0.0.1.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.NdpBooks.Services\bin\Debug\Cadmus.NdpBooks.Services.0.0.1.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.NdpBooks.Parts\bin\Debug\Cadmus.Seed.NdpBooks.Parts.0.0.1.nupkg -source C:\Projects\_NuGet
pause
