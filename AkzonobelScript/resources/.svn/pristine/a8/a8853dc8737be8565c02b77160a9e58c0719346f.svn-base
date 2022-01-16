
/**
* формирование снилс.	
*/
function onSNISL(textBox) {
    var d = document.getElementById(textBox);
    var q = d.value;
    q = q.split(' ').join("");
    q = q.split('-').join("");
    q = q.substr(0, 3) + '-' + q.substr(3, 3) + '-' + q.substr(6, 3) + " " + q.substr(8, 2);
    d.value = q;
}

/**
* формирование даты.	
*/
function onDateformat(textBox) {
    var d = document.getElementById(textBox);
    var q = d.value;
    var dDate = new Date();
    q = q.replace(".", "");
    q = q.replace(".", "");
    q = q.replace(".", "");
    q = q.replace(/,/g, "");
    if (q.length == 4) {
        q = maxdaymonth(q.substr(0, 2), q.substr(2, 2), dDate.getFullYear()) + '.' + dDate.getFullYear();
    }
    else {
        if (q.length == 5) {
            q = maxdaymonth(q.substr(0, 2), q.substr(2, 2), '.201' + q.substr(4, 1)) + '.201' + q.substr(4, 1);
        }
        else {
            if (q.length == 6) {
                q = maxdaymonth(q.substr(0, 2), q.substr(2, 2), '.20' + q.substr(4, 2)) + '.20' + q.substr(4, 2);
            }
            else {
                if (q.length == 7) {
                    q = maxdaymonth(q.substr(0, 2), q.substr(2, 2), '.20' + q.substr(4, 2)) + '.20' + q.substr(4, 2);
                }
                else {
                    if (q.length == 8) {
                        q = maxdaymonth(q.substr(0, 2), q.substr(2, 2), q.substr(4, 4)) + '.' + q.substr(4, 4);
                    }
                    else {
                        if (q.length == 9) {
                            q = maxdaymonth(q.substr(0, 2), q.substr(2, 2), q.substr(4, 4)) + '.' + q.substr(4, 4);
                        }
                        else {
                            if (q.length == 10) {
                                q = maxdaymonth(q.substr(0, 2), q.substr(2, 2), q.substr(4, 4)) + '.' + q.substr(4, 4);
                            }
                        }
                    }
                }
            }
        }
    }
    d.value = q;
}
/**
* формирование даты удаление запредельных дат	
*/
function maxdaymonth(d, m, y) {
    if (m > 12)
        m = 12;
    if (m == '01' || m == '03' || m == '05' || m == '07' || m == '08' || m == '10' || m == '12') {
        if (d > 31)
        { d = 31; }
    }
    if (m == '04' || m == '06' || m == '09' || m == '11') {
        if (d > 30)
        { d = 30; }
    }
    if (m == '02' && d > 27) {
        if (!checkYear(y))
        { d = 28; } else { d = 29; }
    }
    return d + '.' + m;
}
/**
* проверка на высокосный год	
*/
function checkYear(year) {
    return (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) ? 1 : 0;
}

/**
* Игнорирование нажатия с клавы	
*/
function EnsureNull(evt) {
    var evt = window.event || evt;
    if (evt.keyCode == 9) {
        return false;
    }
    else {
        evt.returnValue = false; //for IE
        if (evt.preventDefault)  //for FF
        {
            evt.preventDefault();
            evt.stopPropagation();
        }
    }
}

/**
* Ввод только целых цифр	
*/
function EnsureInt(evt) {
    var evt = window.event || evt;
    if (evt.keyCode == 48 || evt.keyCode == 49 || evt.keyCode == 50 || evt.keyCode == 51 || evt.keyCode == 52 || evt.keyCode == 53 || evt.keyCode == 54 || evt.keyCode == 55 || evt.keyCode == 56 || evt.keyCode == 57 || evt.keyCode == 8 || evt.keyCode == 9 || evt.keyCode == 37 || evt.keyCode == 39 || evt.keyCode == 96 || evt.keyCode == 97 || evt.keyCode == 98 || evt.keyCode == 99 || evt.keyCode == 100 || evt.keyCode == 101 || evt.keyCode == 102 || evt.keyCode == 103 || evt.keyCode == 104 || evt.keyCode == 105 || evt.keyCode == 46 || evt.keyCode == 127) {
        return false;
    }
    else {
        evt.returnValue = false; //for IE
        if (evt.preventDefault)  //for FF
        {
            evt.preventDefault();
            evt.stopPropagation();
        }
    }
}

/**
* Ввод СНИЛС
*/
function EnsureSnils(evt) {
    var evt = window.event || evt;
    if (evt.keyCode == 48 || evt.keyCode == 49 || evt.keyCode == 50 || evt.keyCode == 51 || evt.keyCode == 52 || evt.keyCode == 53 || evt.keyCode == 54 || evt.keyCode == 55 || evt.keyCode == 56 || evt.keyCode == 57 || evt.keyCode == 8 || evt.keyCode == 37 || evt.keyCode == 39 || evt.keyCode == 96 || evt.keyCode == 97 || evt.keyCode == 98 || evt.keyCode == 99 || evt.keyCode == 100 || evt.keyCode == 101 || evt.keyCode == 102 || evt.keyCode == 103 || evt.keyCode == 104 || evt.keyCode == 105 || evt.keyCode == 127 || evt.keyCode == 45 || evt.keyCode == 189 || evt.keyCode == 32 || evt.keyCode == 109) {
        return false;
    }
    else {
        evt.returnValue = false; //for IE
        if (evt.preventDefault)  //for FF
        {
            evt.preventDefault();
            evt.stopPropagation();
        }
    }
}

/**
* Ввод даты с разделением точка	
*/
function EnsureDate(evt) {
    var evt = window.event || evt;
    if (evt.keyCode == 48 || evt.keyCode == 49 || evt.keyCode == 50 || evt.keyCode == 51 || evt.keyCode == 52 || evt.keyCode == 53 || evt.keyCode == 54 || evt.keyCode == 55 || evt.keyCode == 56 || evt.keyCode == 57 || evt.keyCode == 8 || evt.keyCode == 9 || evt.keyCode == 37 || evt.keyCode == 39 || evt.keyCode == 190 || evt.keyCode == 96 || evt.keyCode == 97 || evt.keyCode == 98 || evt.keyCode == 99 || evt.keyCode == 100 || evt.keyCode == 101 || evt.keyCode == 102 || evt.keyCode == 103 || evt.keyCode == 104 || evt.keyCode == 105 || evt.keyCode == 222 || evt.keyCode == 189 || evt.keyCode == 46 || evt.keyCode == 127) {
        return false;
    }
    else {
        evt.returnValue = false; //for IE
        if (evt.preventDefault)  //for FF
        {
            evt.preventDefault();
            evt.stopPropagation();
        }
    }
}

/**
* Ввод данных с разделением запятая
*/
function EnsureNumeric(evt) {
    var evt = window.event || evt;
    if (evt.keyCode == 48 || evt.keyCode == 49 || evt.keyCode == 50 || evt.keyCode == 51 || evt.keyCode == 52 || evt.keyCode == 53 || evt.keyCode == 54 || evt.keyCode == 55 || evt.keyCode == 56 || evt.keyCode == 57 || evt.keyCode == 8 || evt.keyCode == 9 || evt.keyCode == 37 || evt.keyCode == 39 || evt.keyCode == 188 || evt.keyCode == 109 || evt.keyCode == 96 || evt.keyCode == 97 || evt.keyCode == 98 || evt.keyCode == 99 || evt.keyCode == 100 || evt.keyCode == 101 || evt.keyCode == 102 || evt.keyCode == 103 || evt.keyCode == 104 || evt.keyCode == 105 || evt.keyCode == 222 || evt.keyCode == 189 || evt.keyCode == 192 || evt.keyCode == 46 || evt.keyCode == 127 || evt.keyCode == 190) {
        return false;
    }
    else {
        evt.returnValue = false; //for IE
        if (evt.preventDefault)  //for FF
        {
            evt.preventDefault();
            evt.stopPropagation();
        }
    }
}

/* Функция считывает параметр по имени */
function getPar(name) {
    paramStr = window.location.search;
    begin = paramStr.indexOf(name) + name.length + 1;
    end = paramStr.indexOf('&', begin);
    if (end == -1) end = paramStr.length;
    return unescape(paramStr.substring(begin, end));
}

function go() {
    this.parent.frames[0].parent.hidePopWin(false);
}

function go1() {
    alert('1');
    alert(this.parent.frames[0].name);
    this.parent.frames[0].parent.hidePopWin(false);
}
