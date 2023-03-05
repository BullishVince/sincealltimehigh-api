//Call the following url to get a table containing all assets on the swedish market (Large-, Mid- and Small-cap)
//https://www.avanza.se/frontend/template.html/marketing/advanced-filter/advanced-filter-template?1678030192141&widgets.marketCapitalInSek.filter.lower=&widgets.marketCapitalInSek.filter.upper=&widgets.marketCapitalInSek.active=true&widgets.stockLists.filter.list%5B0%5D=SE.SmallCap.SE&widgets.stockLists.filter.list%5B1%5D=SE.LargeCap.SE&widgets.stockLists.filter.list%5B2%5D=SE.MidCap.SE&widgets.stockLists.active=true&widgets.numberOfOwners.filter.lower=&widgets.numberOfOwners.filter.upper=&widgets.numberOfOwners.active=true&parameters.startIndex=0&parameters.maxResults=500&parameters.selectedFields%5B0%5D=LATEST&parameters.selectedFields%5B1%5D=DEVELOPMENT_TODAY&parameters.selectedFields%5B2%5D=DEVELOPMENT_ONE_YEAR&parameters.selectedFields%5B3%5D=MARKET_CAPITAL_IN_SEK&parameters.selectedFields%5B4%5D=PRICE_PER_EARNINGS&parameters.selectedFields%5B5%5D=DIRECT_YIELD&parameters.selectedFields%5B6%5D=NBR_OF_OWNERS&parameters.selectedFields%5B7%5D=LIST

const axios = require('axios');
const cheerio = require('cheerio');

const url = 'https://www.avanza.se/frontend/template.html/marketing/advanced-filter/advanced-filter-template?1678030192141&widgets.marketCapitalInSek.filter.lower=&widgets.marketCapitalInSek.filter.upper=&widgets.marketCapitalInSek.active=true&widgets.stockLists.filter.list%5B0%5D=SE.SmallCap.SE&widgets.stockLists.filter.list%5B1%5D=SE.LargeCap.SE&widgets.stockLists.filter.list%5B2%5D=SE.MidCap.SE&widgets.stockLists.active=true&widgets.numberOfOwners.filter.lower=&widgets.numberOfOwners.filter.upper=&widgets.numberOfOwners.active=true&parameters.startIndex=0&parameters.maxResults=500&parameters.selectedFields%5B0%5D=LATEST&parameters.selectedFields%5B1%5D=DEVELOPMENT_TODAY&parameters.selectedFields%5B2%5D=DEVELOPMENT_ONE_YEAR&parameters.selectedFields%5B3%5D=MARKET_CAPITAL_IN_SEK&parameters.selectedFields%5B4%5D=PRICE_PER_EARNINGS&parameters.selectedFields%5B5%5D=DIRECT_YIELD&parameters.selectedFields%5B6%5D=NBR_OF_OWNERS&parameters.selectedFields%5B7%5D=LIST';

const links = [];

axios.get(url)
  .then(response => {
    const html = response.data;
    const $ = cheerio.load(html);
    const column2Links = $('table tr td:nth-child(2) a').map((i, el) => $(el).attr('href')).get();
    column2Links.forEach((link) => links.push(`https://www.avanza.se/${link}`));
  })
  .catch(error => {
    console.error(error);
  })
  .finally(() => {
    links.forEach(link => {
      axios.get(link)
        .then(response => {
          const html = response.data;
          const $ = cheerio.load(html);
          console.log($.text().trim());
          // const shortName = $('mint-pair-list-value[_ngcontent-mjv-c321].value').text().trim();
          // console.log(shortName);
        })
    });
  });