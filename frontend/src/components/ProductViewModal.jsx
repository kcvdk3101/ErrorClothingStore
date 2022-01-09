import React, { useEffect, useState } from "react";

import { useSelector, useDispatch } from "react-redux";

import ProductView from "./ProductView";

import Button from "./Button";

import { remove } from "../redux/product-modal/productModalSlice";

// import productData from "../assets/fake-data/products";

const ProductViewModal = (props) => {
  const productSlug = useSelector((state) => state.productModal.value);
  const dispatch = useDispatch();

  const filterProductBySlug = props.data.find(
    (item) => item.slug === productSlug
  );

  const [product, setProduct] = useState(undefined);

  // const getProductBySlug = (slug) => props.item.find((e) => e.slug === slug);

  // console.log(getProductBySlug(productSlug));

  useEffect(() => {
    setProduct(filterProductBySlug);
  }, [filterProductBySlug, productSlug]);

  return (
    <div
      className={`product-view__modal ${product === undefined ? "" : "active"}`}
    >
      <div className="product-view__modal__content">
        <ProductView product={product} />
        <div className="product-view__modal__content__close">
          <Button size="sm" onClick={() => dispatch(remove())}>
            đóng
          </Button>
        </div>
      </div>
    </div>
  );
};

export default ProductViewModal;
