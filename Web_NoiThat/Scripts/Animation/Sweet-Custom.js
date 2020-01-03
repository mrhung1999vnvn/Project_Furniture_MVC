$('#btnUpdate').on('click', function () {
    
    Swal.fire({
        title: 'You want update this product?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#46b3e6',
        cancelButtonColor: '#f67280',
        confirmButtonText: 'Yes, of course!'
    }).then((result) => {
        if (result.value) {
            Swal.fire(
                'Updated!',
                'Your product have updated.',
                'success'
            )
            $('form#updatedForm').submit();
        }
    })
});

function Delete() {
    Swal.fire({
        title: 'You want update this product?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#46b3e6',
        cancelButtonColor: '#f67280',
        confirmButtonText: 'Yes, of course!'
    }).then((result) => {
        if (result.value) {
            Swal.fire(
                'Updated!',
                'Your product have updated.',
                'success'
            )
            $('form#updatedForm').submit();
        }
    })
}

function UpdatedLater() {
    Swal.fire({
        icon: 'error',
        title: 'The function will update later!!!!',
        showClass: {
            popup: 'animated fadeInDown faster'
        },
        hideClass: {
            popup: 'animated fadeOutUp faster'
        }
    })
}

