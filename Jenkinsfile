#!groovy​
// System.setProperty("hudson.model.DirectoryBrowserSupport.CSP", "sandbox; img-src 'self'; style-src 'unsafe-inline'")

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
		
		stage 'Unit tests and Selenium Tests'
			bat "\"C:\\Program Files (x86)\\NUnit.org\\nunit-console\\nunit3-console.exe\" TestApplication.Tests\\bin\\Release\\TestApplication.Tests.dll --result:nunit-result.xml;format=nunit2"
		
		stage 'Convert Nunit test results to HTML'
			// CHANGE EXE NAME BEFORE PROD
			bat "\"C:\\HTML Report\\NUnitHTMLReportGenerator.exe\" \"C:\\Program Files (x86)\\Jenkins\\workspace\\denemeMultiBranch\\master\\nunit-result.xml\""
	
		stage 'Publish Nunit Test Report'
			publishHTML(target: [allowMissing: false, alwaysLinkToLastBuild: true, keepAll: true, reportDir: '', reportFiles: 'nunit-result.html', reportName: 'Nunit Test Results'])
	}
}