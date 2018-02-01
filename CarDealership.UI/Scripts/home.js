$(document).ready(function () {
    vendingInventory();
    $('#dollar').click(function () {
        AddMoney('dollar');
    });
    $('#quarter').click(function () {
        AddMoney('quarter');
    });
    $('#dime').click(function () {
        AddMoney('dime');
    });
    $('#nickel').click(function () {
        AddMoney('nickel');
    });
})





//$('#makePurchase').on('click', function () {


//    var money = parseFloat($('#money-insert').val()).toFixed(2);
//    var itemNumber = $('#purchase-item-message').val();

    
//    $.ajax({


//        type: 'GET',
//        url: 'http://localhost:8080/money/' + money + '/item/' + itemNumber,
//        success: function (vendingData) {

//            var changeMessage = '';

//            if (vendingData.quarters != 0) changeMessage += 'Quarters: ' + vendingData.quarters;

//            if (vendingData.dimes != 0) changeMessage += ' Dimes: ' + vendingData.dimes;
            
//            if (vendingData.nickels != 0) changeMessage += ' Nickels: ' + vendingData.nickels;
            
//            if (vendingData.pennies != 0) changeMessage += ' Pennies: ' + vendingData.pennies;

//            $('#money-returned').val(changeMessage);

            
//            $('#purchase-message').val('Thank You!!!');
//            $('#money-insert').val('');
//            vendingInventory();
            
//        },
//        error: function (a, b, c) {

//            var response = JSON.parse(a.responseText)

//            $('#purchase-message').val(response.message);
//        }

        
//    });


//});

//$('#change-returned').on('click', function () {


//    CancelTransaction();

//    $('#purchase-message').val('');
//    $('#money-insert').val('');
//    $('#purchase-item-message').val('');
//});



//$('#itemCollection').on('click','button', function (event) {
  
//    var item = event.currentTarget.id;
//    $('#purchase-item-message').val(item);
//});

function vendingInventory() {


    $('#itemCollection').empty();
    
    $.ajax({


        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function (vendingData) {


            $.each(vendingData, function (index, vendingItem) {


                $('#tmpl').addClass('col-md-offset-1').attr("width","167px");
                var template = $('#tmpl').html();
               

                var html = template
                    .replace('{{ItemId}}', vendingItem.id)
                    .replace('{{Number}}', vendingItem.id)
                    .replace('{{Name}}', vendingItem.name)
                    .replace('{{Price}}', '$' + vendingItem.price.toFixed(2))
                    .replace('{{Quantity}}', vendingItem.quantity);


                if ((index + 1) % 3 == 0) html = html + '<<br /><br />';
                
               
                $('#itemCollection').append(html);

                
                



            });



        },
        error: function (a, b, c) {
            alert('ERROR');
        }



    });

   
   

}



function AddMoney(buttonId)
{
     var currentValue = parseFloat($('#money-insert').val());
     var output
    if (isNaN(currentValue))
    {
        currentValue = Number(0.00);
    }
    else
    { curentValue = Number(currentValue);}
    switch (buttonId) {

        case 'dollar':
            output = (currentValue + 1.00).toFixed(2);
            break;
        case 'quarter':
            output = (currentValue + 0.25).toFixed(2);
            break;
        case 'nickel':
            output = (currentValue + 0.05).toFixed(2);
            break;
        case 'dime':
            output = (currentValue + 0.10).toFixed(2);
            break;
    }


    $('#money-insert').val(output);
}

function CancelTransaction()
{

  
    var change = Number(parseFloat($('#money-insert').val()) * 100);
   
    if (isNaN(change)) return;
    var quarters = 0;
    var dimes = 0;
    var nickels = 0;
    var pennies = change % 5;
    var temp = 0;
    var message = '';

    change = change - pennies;

   
    if (((change % 25) == +0) && ((Math.floor(change / 25)) >= +0)) {
        quarters = change / 25;
        change = 0;
    }
    else {
       
            quarters = Math.floor(change / 25);
            change = change - (quarters * 25);
        
    }

    if (((change % 10) == +0) && (Math.floor(change / 10) >= +0)) {
        dimes = change / 10;
        change = 0;
    }
    else {
       
            dimes = Math.floor(change / 10);
            change = change - (dimes * 10);
        
    }


    if (((change % 5) == +0) && (Math.floor(change / 5) >= +0 )) {
        nickels = change / 5;
        change = 0;
    }
    else
    {
       
            nickels = Math.floor(change / 5);
            change = change - (nickels * 5);
        
    }

   

    if (quarters != 0) message += 'Quarters: ' + quarters + ' ';
    if (dimes != 0) message += 'Dimes: ' + dimes + ' ';
    if (nickels != 0) message += 'Nickels: ' + nickels + ' ';
    if (pennies != 0) message += 'Pennies: ' + pennies + ' ';

    $('#money-returned').val(message);

}
