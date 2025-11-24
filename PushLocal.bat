@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.NdpBooks.Parts\bin\Debug\Cadmus.NdpBooks.Parts.2.0.0.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.NdpBooks.Services\bin\Debug\Cadmus.NdpBooks.Services.2.0.0.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.NdpBooks.Parts\bin\Debug\Cadmus.Seed.NdpBooks.Parts.2.0.0.nupkg -source C:\Projects\_NuGet
pause
