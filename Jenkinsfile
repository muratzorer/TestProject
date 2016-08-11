#!groovy​

node {
	// Mark the code checkout 'stage'....
	stage 'Checkout'

	   // Checkout code from repository
	   checkout scm
		
	stage 'Nuget'
	
		bat 'nuget restore TestApplication.sln'
		
	stage 'MSBuild'
	
		bat "\"${tool 'msbuild'}\" TestApplication.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:VisualStudioVersion=12.0 /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
		
	stage 'Stash/Archive build artifacts'
	
		dir('MvcApplication/bin/Release/**'') {stash name: 'release'}
}

checkpoint 'Completed tests'

node {
    echo 'deployment'
}