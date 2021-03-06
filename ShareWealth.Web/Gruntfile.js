module.exports = function(grunt) {

    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        less: {
            development: {
                options: {
                    paths: ["css"]
                },
                files: {
                    "app/css/app.css": "less/app.less",
                },
                cleancss: true
            },
            /*production: {
                options: {
                    paths: ["css"],
                    cleancss: true,
                },
                files: {
                    "css/app.min.css": "less/app.less",
                }
            },*/
        },
        csssplit: {
            your_target: {
                src: ['app/css/app.css'],
                dest: 'app/css/app.min.css',
                options: {
                    maxSelectors: 4095,
                    suffix: '.'
                }
            },
        },
        ngtemplates: {
          stockApp: {
            src: 'app/includes/**.html',
            dest: 'app/js/templates.js',
            options: {
              htmlmin: { 
                  collapseWhitespace: true, 
                  collapseBooleanAttributes: true 
              }
            }
          }
        },
        watch: {
            styles: {
                files: ['app/less/**/*.less'], // which files to watch
                tasks: ['app/less', 'csssplit'],
                options: {
                    nospawn: true
                } 
            }
        }
    });
  
    // Load the plugin that provides the "less" task.
    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.loadNpmTasks('grunt-csssplit');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-angular-templates');
  
    // Default task(s).
    grunt.registerTask('default', ['less', 'csssplit', 'ngtemplates']);
    
};