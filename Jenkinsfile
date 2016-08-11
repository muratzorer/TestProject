#!groovy​


node { //node('windows') tags
	wrap([$class: 'TimestamperBuildWrapper']) {
		// Mark the code checkout 'stage'....
		stage 'Checkout'
		   // Checkout code from repository
		   checkout scm
			
		stage 'Nuget'
			bat 'nuget restore TestApplication.sln'
			
		stage 'MSBuild'
			timeout(time:60, unit:'SECONDS') {
				bat "\"${tool 'msbuild'}\" TestApplication.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:VisualStudioVersion=12.0 /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
			}
				
		stage 'Stash/Archive build artifacts'
			stash name: "release", includes: "bin/Release/**"
	}
}