
$('#searchresults').on('click', 'button', function (event) {

    var id = $(this).attr('id');

    window.location = "/sales/purchase/" + id;

});



$('#btnSearch').on('click', function (event) {

    event.preventDefault();


    $('#searchresults').empty();

    var priceMin = $('#minPrice option:selected').index();
    var priceMax = $('#maxPrice option:selected').index();
    var yearMin = $('#minYear option:selected').index();
    var yearMax = $('#maxYear option:selected').index();
    if (priceMin != 0) {
        priceMin = $('#minPrice option:selected').val();
    }
    else {
        priceMin = null;
    };

    if (priceMax != 0) {
        priceMax = $('#maxPrice option:selected').val();
    }
    else {
        priceMax = null;
    };

    if (priceMax < priceMin) {
        alert('Price Max is Lower than Price Min. Please adjust.');
        return;
    }



    if (yearMin != 0) {
        yearMin = $('#minYear option:selected').val();
    }
    else
    { yearMin = null };



    if (yearMax != 0) {
        yearMax = $('#maxYear option:selected').val();
    }
    else
    { yearMax = null };

    if (yearMax < yearMin) {
        alert('Year Max is Lower than Year Min. Please adjust. ');
        return;
    }


    var search = $('#search').val();


    var package = { keyWords: search, minPrice: priceMin, maxPrice: priceMax, minYear: yearMin, maxYear: yearMax, type: null, stillAvailable: true };
    var searchString = $.param(package);

    $.ajax({
        type: 'GET',
        url: '/inventory/new/search/?' + searchString,
        contentType: 'application/json',
        success: function (data) {


            $.each(data, function (index, item) {


                $('#tmpl').addClass('col-md-offset-1').attr("width", "167px");
                var template = $('#tmpl').html();


                var html = template

                    .replace('{{Make}}', item.make)
                    .replace('{{Model}}', item.model)
                    .replace('{{Type}}', item.Type)
                    .replace('{{BodyStyle}}', item.bodyStyle)
                    .replace('{{Year}}', item.year)
                    .replace('{{Transmission}}', item.transmission)
                    .replace('{{Color}}', item.color)
                    .replace('{{Interior}}', item.interior)
                    .replace('{{Mileage}}', item.mileage)
                    .replace('{{VIN}}', item.vin)
                    .replace('{{MSRP}}', item.msrp.toLocaleString())
                    .replace('{{SalesPrice}}', item.salesPrice.toLocaleString())
                    .replace('{{Picture}}', item.picture)
                    .replace('{{id}}', item.inventoryId);


                html = html + '<br />';


                $('#searchresults').append(html);

            });

            console.log("it worked!");

        },
        error: function (a, b, c) {
            alert("failure");
        }

    });


});