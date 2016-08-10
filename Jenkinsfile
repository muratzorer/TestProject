node {
	// Mark the code checkout 'stage'....
	stage 'Checkout'

	   // Checkout code from repository
	   checkout scm
   
	stage 'Stage 2'
   
		echo 'Hello World 2'
		
	stage 'Nuget'
	
		bat 'nuget restore TestApplication.sln'
		
	stage 'MSBuild'
	
		bat bat "\"${tool 'msbuild'}\" TestApplication.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
}