param(
    $path,
    $os
)

Write-Host $path
Write-Host $os

$start = $pwd

cd $path

$dotnetRelease = Invoke-WebRequest 'https://dotnetcli.blob.core.windows.net/dotnet/release-metadata/8.0/releases.json' | ConvertFrom-Json

$dotnetVersion = $dotnetRelease."latest-release" 

if($os -eq "win"){
    $file = "dotnet-sdk-win-x64.zip"
}else{
    $file = "dotnet-sdk-linux-x64.tar.gz"
}

$dotnetSdkZipUrl = $dotnetRelease.releases[0].sdk.files | where { $_.name -eq $file } | Select -ExpandProperty "url" | Out-String

Write-Host "Download dotnet version: $dotnetVersion"
Write-Host "Download from cdn: $dotnetSdkZipUrl"

if($os -eq "win"){
    $dfile = "dontet_version_$dotnetVersion.zip"
}else{
    $dfile = "dontet_version_$dotnetVersion.tar.gz"
}

Invoke-RestMethod -Uri $dotnetSdkZipUrl -OutFile "$path\$dfile"

Write-Host "Download successfully to $path\$dfile" 

if($os -eq "win"){
    Expand-Archive -LiteralPath "$path\\$dfile" -DestinationPath "$path\dontet_version_$dotnetVersion_$os"
}else{
    mkdir "$path/dontet_version_$dotnetVersion_$os"
    tar -zxvf "$path/$dfile" -C "$path/dontet_version_$dotnetVersion_$os"
}

Write-Host "Extraxt successfully"

if($os -eq "win"){
    cd "$path\dontet_version_$dotnetVersion_$os\packs\Microsoft.NETCore.App.Host.win-x64\$dotnetVersion\runtimes\win-x64\native"
}else{
    cd "$path\dontet_version_$dotnetVersion_$os\packs\Microsoft.NETCore.App.Host.linux-x64\$dotnetVersion\runtimes\linux-x64\native"
}

Write-Host "Pack libnethost"

if($os -eq "win"){
    tar -cvzf $path\libnethost.tar *
}else{
    tar -cvzf "$path/libnethost.tar" *
}

Write-Host "Pack successfully"

cd $start