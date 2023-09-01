const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "https://localhost:7055",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
