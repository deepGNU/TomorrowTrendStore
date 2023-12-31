import React, { useState, useEffect } from 'react';
import './RotatingList.css';
import Product from '../product/Product';
import {
    FaArrowAltCircleRight as RightArrow,
    FaArrowAltCircleLeft as LeftArrow
} from "react-icons/fa";

const RotatingList = ({ items, rotationInterval = 5000 }) => {
    const [currentItems, setCurrentItems] = useState(items);

    const rotateForward = () => {
        setCurrentItems(prevItems => {
            const [first, ...rest] = prevItems;
            return [...rest, first];
        });
    };

    const rotateBackward = () => {
        setCurrentItems(prevItems => {
            const last = prevItems[prevItems.length - 1];
            return [last, ...prevItems.slice(0, prevItems.length - 1)];
        });
    };

    useEffect(() => {
        if (items.length < 4) {
            return;
        }

        const intervalId = setInterval(() => {
            setCurrentItems(prevItems => {
                const [first, ...rest] = prevItems;
                return [...rest, first];
            });

        }, rotationInterval);

        return () => clearInterval(intervalId);
    }, [rotationInterval. items?.length]);

    return (
        <div className="product-list-container">
            {items.length > 3 &&
                <button
                    title='Previous'
                    className='btn-product-list'
                    onClick={rotateBackward}>
                    <LeftArrow />
                </button>}

            <div className='product-list'>
                {currentItems.map((item, index) => (
                    <Product className={index < 3 ? 'show' : 'hide'} key={item.id} product={item} />
                ))}
            </div>

            {items.length > 3 &&
                <button
                    title='Next'
                    className='btn-product-list'
                    onClick={rotateForward}>
                    <RightArrow />
                </button>}
        </div>
    );
};

export default RotatingList;