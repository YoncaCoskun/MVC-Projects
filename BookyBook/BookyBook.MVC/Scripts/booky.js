function search(word) {
    if (word.length < 2)
        return;

    $.ajax(
        {
            url: '/RentTransaction/Search',
            data: { keyword: word },
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var resultHtml = '';
                debugger;
                $.each(data, function (i, item) {
                    resultHtml += '<div class="item" onclick="getBooksByResultType(\'' + item.Type + '\',' + item.Id + ')">' + item.Name + '</div>';
                });

                $('#result').html(resultHtml);
            },
            error: function (err) {

            }

        }
        );
}

function getBooksByResultType(sonucTip, id) {
    $.ajax({
        url: '/RentTransaction/GetBooksByType',
        data: { sonucTipi: sonucTip, id: id },
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            var resultHtml = '';
            $.each(data, function (i, item) {
                resultHtml += '<a href="/RentTransaction/Detail/' + item.Id + '"><div class="bookBox"><img src="' + item.PhotoPath + '"/><br/><br/><span>' + item.Name + '</span></div></a>';
            });

            $('#result').html(resultHtml);
        },
        error: function (err) {
            debugger;
        }

    });


}