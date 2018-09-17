const express = require('express');


const router = express.Router();

router.get('/', (req, res, next) => {
    res.status(200).json({
        message: 'Handling GET requests to /products'
    });
});

router.post('/', (req, res, next) => {
    const product = {
        name: req.body.name,
        price: req.body.price
    };

    res.status(201).json({
        message: 'Handling POST requests to /products',
        product: product
    });
})

router.get('/:productId', (req, res, next) => {
    const productId = req.params.productId;
    if(productId==='varun') {
        res.status(200).json({
            message: `You have discovered special id ${productId}`
        })
    } else {
        res.status(200).json({
            message: `You passed ${productId}`
        })
    }
})

router.patch('/:productId', (req, res, next) => {
    res.status(200).json({
        message: `${req.params.productId} Updated`
    })
})

router.delete('/:productId', (req, res, next) => {
    res.status(200).json({
        message: `${req.params.productId} Deleted`
    })
})


module.exports = router;