function Export-Unpack ($solutionName) {
  $exportTemp = "export-temp"  
  $unpackFolder = "src/$solutionName/unpacked-solution"

  pac solution export --name $solutionName --path $exportTemp
  pac solution unpack --zipfile "$exportTemp/$solutionName.zip" --folder $unpackFolder --allowDelete true

  $msappFiles = Get-ChildItem -Path "$unpackFolder/CanvasApps" -Filter *.msapp
  foreach ($msappFile in $msappFiles) {
      $directoryToCreate = $msappFile.FullName.Replace(".msapp","_msapp")
      New-Item -Path $directoryToCreate -Type Directory -Force
      pac canvas unpack --msapp $msappFile.FullName --sources $directoryToCreate
  }

  Get-ChildItem -Path $unpackFolder -Recurse -Filter *.json | 
    ForEach-Object {
      #skip canvas app folder because canvas team already handles this for canvas unpack
      if(-not $_.FullName.Contains('CanvasApps')) {
        Write-Host $_.FullName
        $formatted = jq . $_.FullName --sort-keys
        $formatted | Out-File $_.FullName -Encoding UTF8
      }
    }
}

pac solution publish
Export-Unpack "SelfContainedSolutionTest"