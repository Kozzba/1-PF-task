import React from 'react';

function ExchangeRateDetail({ exchangeRate, onClose }) {
  return (
    <div className="container full-page">
      <h2>Detail kurzovního lístku</h2>
      {exchangeRate ? (
        <div>
          <p>Název: {exchangeRate.name}</p>
          <p>Země: {exchangeRate.country}</p>
          <p>Koupě: {exchangeRate.valBuy}</p>
          <p>Prodej: {exchangeRate.valSell}</p>
        </div>
      ) : (
        <p>Vyberte měnu pro zobrazení detailů</p>
      )}
      <button onClick={onClose}>Zavřít</button>
    </div>
  );
}

export default ExchangeRateDetail;
