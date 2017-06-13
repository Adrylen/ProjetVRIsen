pipeline {
	agent any
	
	environment {
		list_of_files = sh(script: 'find ./Assets/scripts/ -name "*.cs"', returnStdout: true)
		list_of_utils = sh(script: 'find ./Assets/scripts/utils/ -name "*.cs"', returnStdout: true)
	}

	stages {
		stage('Build') {
			steps {
				script {
					name = ""
					for (letter in list_of_files) {
						if(letter == "\n") {
							echo "File found"
							echo name

							utils = ""
							util_name = ""
							for (util_letter in list_of_utils) {
								if(util_letter == "\n") {
									utils += "${util_name} "
									util_name = ""
								} else {
									util_name += util_letter
								}
							}

							sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${name}"
							sh "mcs -warn:4 -r:./natives/UnityEngine.dll ${name} ${utils}"
							sh "find ./Assets/scripts/ -name \"*.exe\" -delete;"
							name = ""
						} else {
							name += letter
						}
					}
				}
			}
		}
	}
}
