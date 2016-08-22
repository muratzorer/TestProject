#!groovy​
// System.setProperty("hudson.model.DirectoryBrowserSupport.CSP","img-src 'self'; style-src 'unsafe-inline'")
// when to use like ${env.BUILD_NUMBER} ??

node { //node('windows') tags
	try
	{
		wrap([$class: 'TimestamperBuildWrapper']) {
			// script is persisted in build.xml so should be deleted
			stage 'Delete build.xml'
				//sh "set +x"
				//sleep time: 7, unit: 'SECONDS'
				bat "del /F \"C:\\Program Files (x86)\\Jenkins\\jobs\\denemeMultiBranch\\branches\\master\\builds\\%BUILD_NUMBER%\\build.xml\""
				//sleep time: 60, unit: 'SECONDS'
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
				// 'b53c0280-6725-4840-93a2-5b3fb3f65a99' murat-pc
				// 'b32da5ab-259e-4a44-a626-484d7af6e0ac' t1lprvt1869
				def source = fileLoader.fromGit('TestProject', 
					'https://github.com/muratzorer/Pipes.git', 'master', null, '')
					
			//stage 'Run method from the loaded file'
				// bat -buraya string dön-
				//source.printHello()

			stage 'Unit tests and Selenium Tests'
				bat source.nunitStep()
			
			stage 'Convert Nunit test results to HTML'
				// CHANGE EXE NAME BEFORE PROD
				bat "NUnitHTMLReportGenerator \"C:\\Program Files (x86)\\Jenkins\\workspace\\denemeMultiBranch\\master\\nunit-result.xml\""
		
			stage 'Publish Nunit Test Report'
				publishHTML(target: [allowMissing: false, alwaysLinkToLastBuild: true, keepAll: true, reportDir: '', reportFiles: 'nunit-result.html', reportName: 'Nunit Test Results'])
				
			stage 'SonarQube Analysis'
				bat "MSBuild.SonarQube.Runner begin /k:\"TestApplication\" /n:\"Test Application\" /v:1.0.0.${BUILD_NUMBER}"
				bat "\"${tool 'msbuild'}\" TestApplication.sln /t:rebuild /p:VisualStudioVersion=12.0"
				bat 'MSBuild.SonarQube.Runner end'
		}
	}
	finally
	{
		bat "del /F \"C:\\Program Files (x86)\\Jenkins\\jobs\\denemeMultiBranch\\branches\\master\\builds\\%BUILD_NUMBER%\\build.xml\""
		//sleep time: 45, unit: 'SECONDS'
	}
}