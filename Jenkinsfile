#!groovy​
// System.setProperty("hudson.model.DirectoryBrowserSupport.CSP","img-src 'self'; style-src 'unsafe-inline'")
// from https://github.com/danielpalme/ReportGenerator/wiki/Integration -->
// System.setProperty("hudson.model.DirectoryBrowserSupport.CSP", "sandbox allow-scripts; default-src 'self';")
// when to use like ${env.BUILD_NUMBER} ??
// FEATURES:
// - isminde Test geçen csproj'ları sonar'a yollamıyor.



def nodes = fileLoader.fromGit('ProjectNameNodes', 
	'https://github.com/muratzorer/Pipes.git', 'master', null, '')

nodes.Node1()

/*
node() {
	// WE WILL PERSIST ENV VARIABLES FOR APP.CONFİG FİLES IN REPO. NEW BRANCH PER PROJECT.
	stage 'Load files from GitHub'
		def environment, helloworld
		fileLoader.withGit('https://github.com/jenkinsci/workflow-remote-loader-plugin.git', 'master', null, '') {
			helloworld = fileLoader.load('examples/fileLoader/helloworld');
			environment = fileLoader.load('examples/fileLoader/environment');
		}

		stage 'Run methods from the loaded content'
		helloworld.printHello()
		environment.dumpEnvVars()
}
*/