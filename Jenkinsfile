#!groovy​
// System.setProperty("hudson.model.DirectoryBrowserSupport.CSP","img-src 'self'; style-src 'unsafe-inline'")
// when to use like ${env.BUILD_NUMBER} ??

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
				bat "\"${tool 'msbuild'}\" TestApplication.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:VisualStudioVersion=12.0 /p:ProductVersion=1.0.0.%BUILD_NUMBER%"
			}
				
		stage 'Stash/Archive build artifacts'
			waitUntil {
				try {
					//archive 'MvcApplication/bin/**'
					stash name: "release", includes: "MvcApplication/bin/**"
					true
				}
				catch(error) {
					timeout(time:30, unit:'SECONDS') {
						input "Retry the job ?"
						false
					}
				}
			}
		
		//stage 'Unit tests and Selenium Tests'
			//bat 'nunit3-console TestApplication.Tests\\bin\\Release\\TestApplication.Tests.dll --result:nunit-result.xml;format=nunit2'
			
		stage 'Load a file from GitHub'
			def source = fileLoader.fromGit('TestProject', 
				'https://github.com/muratzorer/Pipes.git', 'master', 'b53c0280-6725-4840-93a2-5b3fb3f65a99', '')
				
		//stage 'Run method from the loaded file'
			// bat -buraya string dön-
			//source.printHello()

		stage 'Unit tests and Selenium Tests'
			bat 'source.nunitStep()'
		
		stage 'Convert Nunit test results to HTML'
			// CHANGE EXE NAME BEFORE PROD
			bat "NUnitHTMLReportGenerator \"C:\\Program Files (x86)\\Jenkins\\workspace\\denemeMultiBranch\\master\\nunit-result.xml\""
	
		stage 'Publish Nunit Test Report'
			publishHTML(target: [allowMissing: false, alwaysLinkToLastBuild: true, keepAll: true, reportDir: '', reportFiles: 'nunit-result.html', reportName: 'Nunit Test Results'])
			
		stage 'SonarQube Analysis'
			bat 'MSBuild.SonarQube.Runner begin /k:\"TestApplication\" /n:\"Test Application\" /v:1.0.0.%BUILD_NUMBER%'
			bat "\"${tool 'msbuild'}\" TestApplication.sln /t:rebuild /p:VisualStudioVersion=12.0"
			bat 'MSBuild.SonarQube.Runner end'
	}
}