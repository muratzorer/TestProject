node {
	// Mark the code checkout 'stage'....
	stage 'Checkout'

	   // Checkout code from repository
	   checkout scm
   
	stage 'Stage 2'
   
		echo 'Hello World 2'
		
	stage 'Nuget'
	
		bat 'C:\\Users\\MURAT\\Desktop\\nuget.exe restore TestApplication.sln'
		
	stage 'MSBuild'
	
		echo 'build'
}