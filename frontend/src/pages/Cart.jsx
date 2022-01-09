import React, { useEffect, useState } from 'react'

import { useSelector } from 'react-redux'
import { Link } from 'react-router-dom'

import Helmet from '../components/Helmet'
import CartItem from '../components/CartItem'
import Button from '../components/Button'

import productData from '../assets/fake-data/products'
import numberWithCommas from '../utils/numberWithCommas'

const Cart = () => {

    const cartItems = useSelector((state) => state.cartItems.value)

    const [cartProducts, setCartProducts] = useState(productData.getCartItemsInfo(cartItems))

    const [totalProducts, setTotalProducts] = useState(0)

    const [totalPrice, setTotalPrice] = useState(0)

    useEffect(() => {
        // setCartProducts(productData.getCartItemsInfo(cartItems))
        // setTotalPrice(cartItems.reduce((total, item) => total + (Number(item.quantity) * Number(item.price)), 0))
        // setTotalProducts(cartItems.reduce((total, item) => total + Number(item.quantity), 0))
        if(cartItems){
            setCartProducts(productData.getCartItemsInfo(cartItems));
            setTotalPrice(cartItems.reduce((total, item) => {
                total += (parseInt(item?.quantity, 10) * parseInt(item?.price.replace(/\./g,'').replace(/đ/g,''), 10))
                return total || 0
            }, 0))
            setTotalProducts(cartItems.reduce((total, item) => {
                total += parseInt(item?.quantity)
                return total || 0;
            }, 0))
        }
    }, [cartItems])

    return (
        <Helmet title="Giỏ hàng">
            <div className="cart">
                <div className="cart__info">
                    <div className="cart__info__txt">
                        <p>
                            Bạn đang có {totalProducts} sản phẩm trong giỏ hàng
                        </p>
                        <div className="cart__info__txt__price">
                            <span>Thành tiền:</span> <span>{numberWithCommas(Number(totalPrice))}</span>
                        </div>
                    </div>
                    <div className="cart__info__btn">
                        <Link to = "/payment">
                            <Button size="block">
                                Đặt hàng
                            </Button>
                        </Link>
                        <br></br><br></br>
                        {/* <Button size="block">
                            Đặt hàng
                        </Button> */}
                        <Link to="/catalog">
                            <Button size="block">
                                Tiếp tục mua hàng
                            </Button>
                        </Link>
                        
                    </div>
                </div>
                <div className="cart__list">
                    {
                        cartProducts.map((item, index) => (
                            <CartItem item={item} key={index}/>
                        ))
                    }
                </div>
            </div>
        </Helmet>
    )
}

export default Cart
