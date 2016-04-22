/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/"
};

init();

/**
 * Вызвает методы для объявления необходимых тасков 
 */
function init() {
    setPaths();
    cleanAllCss();
    cleanAllJs();
    minifyAllCss();
    minifyAllJs();
    groupGulpTasks();
}

/**
 * Задает пути к файлам для минификации и очистки
 */
function setPaths() {
    paths.js = paths.webroot + "js/**/*.js";
    paths.minJs = paths.webroot + "js/**/*.min.js";
    
    paths.css = paths.webroot + "css/**/*.css";
    paths.minCss = paths.webroot + "css/**/*.min.css";
    
    paths.concatJsDest = paths.webroot + "js/site.min.js";

    paths.concatSiteCssDest = paths.webroot + "css/site.min.css";
    paths.concatProjectsCssDest = paths.webroot + "css/projects/projects.min.css";
    paths.concatEmployeesCssDest = paths.webroot + "css/employees/employees.min.css";
}

/**
 * Группирует таски
 */
function groupGulpTasks() {
    gulp.task("clean", ["cleanJs:site", "cleanCss:site", "cleanCss:projects", "cleanCss:employees"]);
    gulp.task("min", ["minJs:site", "minCss:site", "minCss:projects", "minCss:employees"]);
}

function cleanAllJs() {
    gulp.task("cleanJs:site", function (cb) {
        rimraf(paths.concatJsDest, cb);
    });
}

function minifyAllJs() {
    gulp.task("minJs:site", function () {
        return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
            .pipe(concat(paths.concatJsDest))
            .pipe(uglify())
            .pipe(gulp.dest("."));
    });
}

function cleanAllCss() {
    gulp.task("cleanCss:site", function (cb) {
        rimraf(paths.concatSiteCssDest, cb);
    });

    gulp.task("cleanCss:projects", function (cb) {
        rimraf(paths.concatProjectsCssDest, cb);
    });

    gulp.task("cleanCss:employees", function (cb) {
        rimraf(paths.concatEmployeesCssDest, cb);
    });
}

function minifyAllCss() {
    gulp.task("minCss:site", function () {
        return gulp.src([paths.css, "!" + paths.minCss])
            .pipe(concat(paths.concatSiteCssDest))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });

    gulp.task("minCss:projects", function () {
        return gulp.src([paths.css, "!" + paths.minCss])
            .pipe(concat(paths.concatProjectsCssDest))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });

    gulp.task("minCss:employees", function () {
        return gulp.src([paths.css, "!" + paths.minCss])
            .pipe(concat(paths.concatEmployeesCssDest))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });
}