#!groovy​
// System.setProperty("hudson.model.DirectoryBrowserSupport.CSP","img-src 'self'; style-src 'unsafe-inline'")
// when to use like ${env.BUILD_NUMBER} ??
// FEATURES:
// - isminde Test geçen csproj'ları sonar'a yollamıyor.



def node = fileLoader.fromGit('ProjectName', 
	'https://github.com/muratzorer/Pipes.git', 'master', null, '')

node.EchoNode()

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