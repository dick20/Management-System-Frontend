/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.language = 'zh-cn';
    var hash = "../Scripts";
    config.filebrowserBrowseUrl = hash + '/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = hash + '/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = hash + '/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = hash + '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = hash + '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = hash + '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.toolbar = 'Full';
    
};
