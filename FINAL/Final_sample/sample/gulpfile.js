var gulp = require('gulp');
var chmod = require('gulp-chmod');
var server = require('gulp-webserver');

gulp.task('serve', function() {
  gulp.src('./')
    .pipe(server({
      port:'8000',
      livereload: true,
	  fallback: './sample.html',
      open: true
    }));
});