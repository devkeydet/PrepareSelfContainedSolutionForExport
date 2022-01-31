function Pack ($solutionName) {
  $packTemp = "pack-temp"  
  $vsSolutionPath = "./src/SelfContainedSolutionTest/code-first"
  $unpackFolder = "src/$solutionName/unpacked-solution"
  $solutionZip = "$packTemp/$solutionName.zip"

  $source = "$vsSolutionPath/Plugins/bin/Release/SelfContainedSolutionTest.Plugins.dll"
  $destination = "$unpackFolder/PluginAssemblies/SelfContainedSolutionTestPlugins-0D938548-626C-4DC8-8AAB-08E6DAD8BA92/SelfContainedSolutionTestPlugins.dll"
  Copy-Item $source $destination -Force

  #pac solution pack --zipfile $solutionZip --folder $unpackFolder --packagetype both
  pac solution pack --zipfile $solutionZip --folder $unpackFolder --packagetype unmanaged
  pac solution pack --zipfile $solutionZip.Replace(".zip","_managed.zip") --folder $unpackFolder --packagetype managed
}
Pack "SelfContainedSolutionTest"