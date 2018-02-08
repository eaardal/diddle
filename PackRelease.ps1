param (
	[Parameter(Mandatory = $true)][string] $Version
)

if (git status --porcelain | Where {$_ -match '^\sM'})
{
	Write-Host "Git has changes. Commit them first and run this script again" -ForegroundColor Red
	return
}

$SourceDirectory = "$pwd"
$BuildDirectoryConsoleClient = "$pwd\Diddle.ConsoleClient\bin\Release"
$BuildDirectoryWpfClient = "$pwd\Diddle.WpfClient\bin\Release"
$ReleasesDirectory = "$pwd\Releases"
$ZipFileNameConsoleClient = "DiddleConsoleApp-$Version.zip"
$ZipFileNameWpfClient = "DiddleWpfApp-$Version.zip"
$ZipFilePathConsoleClient = "$ReleasesDirectory\$ZipFileNameConsoleClient"
$ZipFilePathWpfClient = "$ReleasesDirectory\$ZipFileNameWpfClient"
$Indent = "    "

if (!(Test-Path $BuildDirectoryConsoleClient))
{
	Write-Host "$BuildDirectoryConsoleClient does not exist. Build the project with Release configuration first"
	return
}

if (!(Test-Path $BuildDirectoryWpfClient))
{
	Write-Host "$BuildDirectoryWpfClient does not exist. Build the project with Release configuration first"
	return
}

if (!(Test-Path $ReleasesDirectory))
{
	New-Item -Path $ReleasesDirectory -ItemType Directory
}

Add-Type -AssemblyName "System.IO.Compression.Filesystem"

[System.IO.Compression.ZipFile]::CreateFromDirectory($BuildDirectoryConsoleClient, $ZipFilePathConsoleClient)
Write-Host "Created $ZipFilePathConsoleClient" -ForegroundColor Green

[System.IO.Compression.ZipFile]::CreateFromDirectory($BuildDirectoryWpfClient, $ZipFilePathWpfClient)
Write-Host "Created $ZipFilePathWpfClient" -ForegroundColor Green
