#!groovy​


node('windows') {
	wrap([$class: 'TimestamperBuildWrapper']) {
		// Mark the code checkout 'stage'....
		stage 'Checkout'
		   // Checkout code from repository
		   checkout scm
			
		stage 'Nuget'
			bat 'nuget restore TestApplication.sln'
			

	}
}