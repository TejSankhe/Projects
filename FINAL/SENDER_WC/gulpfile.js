var gulp = require('gulp');
var chmod = require('gulp-chmod');
var server = require('gulp-webserver');

gulp.task('serve', function() {
  gulp.src('./')
    .pipe(server({
      port:'9000',
      livereload: true,
	  fallback: './index.html',
      open: true
    }));
});