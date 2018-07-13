var fs = require('fs');
var glob = require('glob');
var gulp = require('gulp');
var shelljs = require('shelljs');
module.exports = gulp;
var window = {};
var elasticlunr = require('elasticlunr');
var beautify = require('json-beautify');

gulp.task('deploy', function(done) {
    // remove clone folder
    shelljs.rm('-rf', './ej2aspmvc');
    var commitMessage = shelljs.exec('git log -1 --pretty=%B').stdout.trim();
    console.log('COMMIT MESSAGE: ' + commitMessage);
    // create clone directory
    fs.mkdirSync('./ej2aspmvc');
    // navigate to clone location
    shelljs.cd('./ej2aspmvc');
    var appPath = process.env.BRANCH_NAME == 'master' ? 'ej2webmail' : 'ej2webmail';
    // get git url for pull the repository
    var remotePath = 'https://' + process.env.EJ2_AZURE_CRED + '@' + appPath + '.scm.azurewebsites.net:443/' + appPath + '.git';
    shelljs.exec('git init && git fetch ' + remotePath + ' master && git checkout master');
    shelljs.exec('git pull ' + remotePath + ' master');

    // get the removable files and remove it from cloned git repo
    var rmFiles = glob.sync('./**/*', { ignore: ['./', './.git/**'] });
    shelljs.rm('-rf', rmFiles);
    // navigate to root folder
    shelljs.cd('../');

    // copy files from root to cloned location
    var files = glob.sync('{./**/*,./*,./.deployment}', { ignore: ['./', './ej2aspmvc/', './ej2aspmvc/**', './packages/**', './bin/**', './obj/**', './node_modules/**', './gulpfile.js', './package.json', './package-lock.json'] })
    var sourceFiles = [];
    for (var i = 0; i < files.length; i++) {
        if (fs.lstatSync(files[i]).isDirectory() && files[i].split('/').length <= 2) {
            sourceFiles.push(files[i] + '/');
        } else if (files[i].split('/').length <= 2) {
            sourceFiles.push(files[i]);
        }
    }
    shelljs.cp('-R', sourceFiles, './ej2aspmvc/');

    // navigate to cloned location
    shelljs.cd('./ej2aspmvc');
    // git add remote, add files and commit
    shelljs.exec('git remote add master ' + remotePath);
    shelljs.exec('git add . && git commit -m "' + commitMessage + '"');
    // git push changes to remote repo
    var deploy = shelljs.exec('git push ' + remotePath + ' master:master', { silent: false });
    // navigate to roor folder
    shelljs.cd('../');
    if (deploy.code !== 0) {
        console.log(deploy.stderr);
        done();
        process.exit(1);
    } else {
        console.log('Deployed Successfully!!!');
        done();
    }
});

