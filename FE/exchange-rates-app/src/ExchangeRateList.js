import React, { useState, useEffect } from 'react';
import axios from 'axios';

function ExchangeRateList({ onSelectExchangeRate }) { 
  const [currencies, setCurrencies] = useState([]);
  const [useDb, setUseDb] = useState(false);
  let exchangeRatesUrl = process.env.REACT_APP_EXCHANGE_RATES_URL;
  
  if (process.env.NODE_ENV === 'production')  
    exchangeRatesUrl += `${useDb}`;

  const fetchData = async () => {
    const result = await axios(exchangeRatesUrl);
    setCurrencies(result.data);
  };

  useEffect(() => {
    fetchData();
  }, [useDb]);

  return (
    <div>
      <h2>Kurzovní lístky</h2>
      <label>
        Použít databázi:
        <input
          type="checkbox"
          checked={useDb}
          onChange={e => {
            setUseDb(e.target.checked);
          }}
        />
      </label>

      <ul className='exchange-rate-list'>
        {currencies.map((exchangeRate, index) => (
          <li key={index} onClick={() => onSelectExchangeRate(exchangeRate)}>
            {exchangeRate.shortName} - {exchangeRate.valMid}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default ExchangeRateList;
