var textarea = document.getElementsByTagName('textarea')[0];

textarea.addEventListener('keydown', resize);
enableTab('textarea-id');

function resize() {
  var el = this;
  setTimeout(function() {
    el.style.cssText = 'height:auto; padding:1';
    el.style.cssText = 'height:' + el.scrollHeight + 'px';
  }, 1);
}

function enableTab(id) {
    var el = document.getElementById(id);
    el.onkeydown = function (e) {
        if (e.keyCode === 9) { // была нажата клавиша TAB

            // получим позицию каретки
            var val = this.value,
                start = this.selectionStart,
                end = this.selectionEnd;

            // установим значение textarea в: текст до каретки + tab + текст после каретки
            this.value = val.substring(0, start) + '\t' + val.substring(end);

            // переместим каретку
            this.selectionStart = this.selectionEnd = start + 1;

            // предотвратим потерю фокуса
            return false;

        }
    };
}