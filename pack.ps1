function Pack ($solutionName) {
  $packTemp = "pack-temp"  
  $vsSolutionPath = "./src/SelfContainedSolutionTest/code-first"
  $unpackFolder = "src/$solutionName/unpacked-solution"
  $solutionZip = "$packTemp/$solutionName.zip"
  $unPackTemp = "$packTemp/u"

  if (Test-Path $unPackTemp) {
    Remove-Item "$unPackTemp/*" -Recurse -Force
  }
  else {
    New-Item -Path $unPackTemp -ItemType Directory
  }
  
  Copy-Item "$unpackFolder/*" $unPackTemp -Recurse -Force

  # need to delete _msapp folder before packing
  $msappUnpackPath = (Get-ChildItem "$unPackTemp/CanvasApps/*_msapp")[0].FullName
  Remove-Item $msappUnpackPath -Force -Recurse

  $source = "$vsSolutionPath/Plugins/bin/Release/SelfContainedSolutionTest.Plugins.dll"
  $destination = "$unpackFolder/PluginAssemblies/SelfContainedSolutionTestPlugins-BB2613D0-D86D-4460-B4EE-6042046E2ED9/SelfContainedSolutionTestPlugins.dll"
  Copy-Item $source $destination -Force

  #pac solution pack --zipfile $solutionZip --folder $unPackTemp --packagetype both
  pac solution pack --zipfile $solutionZip --folder $unPackTemp --packagetype unmanaged
  pac solution pack --zipfile $solutionZip.Replace(".zip","_managed.zip") --folder $unPackTemp --packagetype managed
}
Pack "SelfContainedSolutionTest"