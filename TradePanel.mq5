//+------------------------------------------------------------------+
//|                                                   TradePanel.mq5 |
//|                                Copyright 2019, Marc Wagener Lux. |
//|                                              http://www.mql5.com |
//+------------------------------------------------------------------+
#property copyright "Copyright 2021, Marc Wagener"
#property link      "http://www.mql5.com"
#property version   "1.50"
#import  "MtGuiController.dll"
#include <Trade\Trade.mqh>
#include <Trade\PositionInfo.mqh>
#include <Trade\OrderInfo.mqh>
string assembly = "C:\\Users\\Marc\\source\\repos\\MQ5\\TradePanel\\TradePanel\\TradePanel\\bin\\Debug\\TradePanel.dll";
string FormName = "TradePanelForm";
double current_volume = 0.0;
//---
CTrade         m_trade;      // trading object
CPositionInfo  m_position;   // position info object
COrderInfo     m_order;      // order info object

//---
enum ENUM_CLOSE_TYPE
  {
   CLOSE_TYPE_ALL,           // Positions and Pending Orders
   CLOSE_TYPE_POSITIONS,     // Positions Only
   CLOSE_TYPE_ORDERS         // Pending Orders
  };
enum ENUM_CLOSE_SYMBOL
  {
   CLOSE_SYMBOL_ALL,         // All Symbols
   CLOSE_SYMBOL_CHART        // Current Chart Symbol
  };
enum ENUM_CLOSE_PROFIT
  {
   CLOSE_PROFIT_ALL,         // All Profit / Loss
   CLOSE_PROFIT_PROFITONLY,  // Profit Only
   CLOSE_PROFIT_LOSSONLY     // Loss Only
  };
//--- input parameters
input ENUM_CLOSE_TYPE   InpCloseType   = CLOSE_TYPE_ALL;   // Type
input ENUM_CLOSE_SYMBOL InpCloseSymbol = CLOSE_SYMBOL_ALL; // Symbols
input ENUM_CLOSE_PROFIT InpCloseProfit = CLOSE_PROFIT_ALL; // Profit / Loss
input string            xx2;                               // ============
input uint              RTOTAL         = 5;                // Retries
input uint              SLEEPTIME      = 1000;             // Sleep Time (msec)
input bool              InpAsyncMode   = true;             // Asynchronous Mode
input bool              InpDisAuto     = false;            // Disable AutoTrading Button
//+------------------------------------------------------------------+
//| Expert initialization function                                   |
//+------------------------------------------------------------------+
int OnInit()
  {
//--- create timer, show window and set volume
   EventSetMillisecondTimer(200);
   GuiController::ShowForm(assembly, FormName);
   current_volume = SymbolInfoDouble(Symbol(), SYMBOL_VOLUME_MIN);
   GuiController::SendEvent("CurrentVolume", MtGuiController.TextChange, 0, 0.0, DoubleToString(current_volume, 2));
   m_trade.SetExpertMagicNumber(999);
   m_trade.SetAsyncMode(InpAsyncMode);
   m_trade.SetDeviationInPoints(ULONG_MAX);
   m_trade.SetMarginMode();
   m_trade.LogLevel(LOG_LEVEL_ERRORS);
//---
   return(INIT_SUCCEEDED);
  }
//+------------------------------------------------------------------+
//| Expert deinitialization function                                 |
//+------------------------------------------------------------------+
void OnDeinit(const int reason)
  {
//--- Dispose form
   EventKillTimer();
   GuiController::HideForm(assembly, FormName);
//---
  }
//+------------------------------------------------------------------+
//| Expert tick function                                             |
//+------------------------------------------------------------------+
void OnTick()
  {
//--- refresh ask/bid
   double ask = SymbolInfoDouble(Symbol(), SYMBOL_ASK);
   double bid = SymbolInfoDouble(Symbol(), SYMBOL_BID);
   GuiController::SendEvent("AskLabel", MtGuiController.TextChange, 0, 0.0, DoubleToString(ask, Digits()));
   GuiController::SendEvent("BidLabel", MtGuiController.TextChange, 0, 0.0, DoubleToString(bid, Digits()));
   
//---
  }

//+------------------------------------------------------------------+
//| Check for Permission to Perform Automated Trading                |
//+------------------------------------------------------------------+
bool VerifyTradingPermissions()
  {
//--- Terminal - internet connection
   if(!TerminalInfoInteger(TERMINAL_CONNECTED))
     {
      Alert("Error: No connection to the trade server!");
      return (false);
     }
//--- Terminal - Checking for permission to perform automated trading in the terminal
   if(!TerminalInfoInteger(TERMINAL_TRADE_ALLOWED))
     {
      Alert("Error: Automated trading is not allowed in the terminal settings, or 'AutoTrading' button is disabled.");
      return (false);
     }
//--- Expert - Checking if trading is allowed for a certain running Expert Advisor/script
   if(!MQLInfoInteger(MQL_TRADE_ALLOWED))
     {
      Alert("Error: Live trading is not allowed in the program properties of '",MQLInfoString(MQL_PROGRAM_NAME),"'");
      return (false);
     }
//---
   return (true);
  }
//+------------------------------------------------------------------+
//| Timer function                                                   |
//+------------------------------------------------------------------+
void OnTimer()
  {
//--- get new events by timer
   for(static int i = 0; i < GuiController::EventsTotal(); i++)
     {
      int id;
      string el_name;
      long lparam;
      double dparam;
      string sparam;
      GuiController::GetEvent(i, el_name, id, lparam, dparam, sparam);
      if(id == MtGuiController.TextChange && el_name == "CurrentVolume")
         TrySetNewVolume(sparam);
      else
         if(id == MtGuiController.ScrollChange && el_name == "IncrementVol")
            OnIncrementVolume(lparam, dparam, sparam);
         else
            if(id == MtGuiController.ClickOnElement)
               TryTradeOnClick(el_name);
     }
//---
  }
//+------------------------------------------------------------------+
//| Validate volume                                                  |
//+------------------------------------------------------------------+
double ValidateVolume(double n_vol)
  {
   double min_vol = SymbolInfoDouble(Symbol(), SYMBOL_VOLUME_MIN);
   double max_vol = SymbolInfoDouble(Symbol(), SYMBOL_VOLUME_MAX);
//-- check min limit
   if(n_vol < min_vol)
      return min_vol;
//-- check max limit
   if(n_vol > max_vol)
      return max_vol;
//-- normalize volume
   double vol_step = SymbolInfoDouble(Symbol(), SYMBOL_VOLUME_STEP);
   double steps = MathRound(n_vol / vol_step);
   double corr_vol = NormalizeDouble(vol_step * steps, 2);
   return corr_vol;
  }
//+------------------------------------------------------------------+
//| Set new current volume from a given text                         |
//+------------------------------------------------------------------+
bool TrySetNewVolume(string nstr_vol)
  {
   double n_vol = StringToDouble(nstr_vol);
   current_volume = ValidateVolume(n_vol);
   string corr_vol = DoubleToString(current_volume, 2);
//GuiController::
   GuiController::SendEvent("CurrentVolume", MtGuiController.TextChange, 0, 0.0, corr_vol);
   return true;
  }
//+------------------------------------------------------------------+
//| Execute trade orders                                             |
//+------------------------------------------------------------------+
bool TryTradeOnClick(string el_name)
  {
   if(el_name == "ButtonBuy")
     {
      m_trade.SetExpertMagicNumber(999);
      return m_trade.Buy(current_volume);
     }
   if(el_name == "ButtonSell")
     {
      m_trade.SetExpertMagicNumber(999);
      return m_trade.Sell(current_volume);
     }
   if(el_name == "ButtonClose")
     {
      if(InpCloseType==CLOSE_TYPE_POSITIONS || InpCloseType==CLOSE_TYPE_ALL)
        {
         for(uint count=0; count<RTOTAL && !IsStopped(); count++)
           {
            bool result = true;
            for(int i=PositionsTotal()-1; i>=0 && !IsStopped(); i--)
              {
               if(!m_position.SelectByIndex(i))
                 {
                  PrintFormat("> Error selecting position with index #%d. Error Code: %d",i,_LastError);
                  result = false;
                  continue;
                 }
               if(InpCloseSymbol==CLOSE_SYMBOL_CHART && m_position.Symbol()!=Symbol())
                 {
                  continue;
                 }
               if(InpCloseProfit==CLOSE_PROFIT_PROFITONLY && m_position.Profit()<=0)
                 {
                  continue;
                 }
               if(InpCloseProfit==CLOSE_PROFIT_LOSSONLY && m_position.Profit()>=0)
                 {
                  continue;
                 }
               //--- trading object
               m_trade.SetExpertMagicNumber(m_position.Magic());
               m_trade.SetTypeFillingBySymbol(m_position.Symbol());
               //--- close positions
               if(m_trade.PositionClose(m_position.Ticket()) && (m_trade.ResultRetcode()==TRADE_RETCODE_DONE || m_trade.ResultRetcode()==TRADE_RETCODE_PLACED))
                  PrintFormat("Position ticket #%I64u on %s to be closed",m_position.Ticket(),m_position.Symbol());
               else
                 {
                  PrintFormat("> Error closing position ticket #%I64u on %s. Retcode=%u (%s)",m_position.Ticket(),m_position.Symbol(),m_trade.ResultRetcode(),m_trade.ResultComment());
                  result = false;
                 }
              }
            if(result)
               break;
            //Sleep(SLEEPTIME);
           }
        }
      if(InpCloseType==CLOSE_TYPE_ORDERS || InpCloseType==CLOSE_TYPE_ALL)
        {
         for(uint count=0; count<RTOTAL && !IsStopped(); count++)
           {
            bool result = true;
            for(int i=OrdersTotal()-1; i>=0 && !IsStopped(); i--)
              {
               if(!m_order.SelectByIndex(i))
                 {
                  PrintFormat("> Error selecting order with index #%d. Error Code: %d",i,_LastError);
                  result = false;
                  continue;
                 }
               if(InpCloseSymbol==CLOSE_SYMBOL_CHART && m_position.Symbol()!=Symbol())
                 {
                  continue;
                 }
               //--- delete orders
               if(m_trade.OrderDelete(m_order.Ticket()) && (m_trade.ResultRetcode()==TRADE_RETCODE_DONE || m_trade.ResultRetcode()==TRADE_RETCODE_PLACED))
                  PrintFormat("Order ticket #%I64u on %s to be deleted",m_order.Ticket(),m_order.Symbol());
               else
                 {
                  PrintFormat("> Error deleting order ticket #%I64u on %s. Retcode=%u (%s)",m_order.Ticket(),m_order.Symbol(),m_trade.ResultRetcode(),m_trade.ResultComment());
                  result = false;
                 }
              }
            if(result)
               break;
            Sleep(SLEEPTIME);
           }
        }
     }
   return false;
  }

//+------------------------------------------------------------------+
//| Increment or decrement current volume                            |
//+------------------------------------------------------------------+
void OnIncrementVolume(long lparam, double dparam, string sparam)
  {
   double vol_step = 0.0;
//-- detect increment press
   if(dparam > lparam)
      vol_step = (-1.0) * SymbolInfoDouble(Symbol(), SYMBOL_VOLUME_STEP);
//-- detect decrement press
   else
      if(dparam < lparam)
         vol_step = SymbolInfoDouble(Symbol(), SYMBOL_VOLUME_STEP);
      //-- detect increment press again
      else
         if(lparam == 0)
            vol_step = SymbolInfoDouble(Symbol(), SYMBOL_VOLUME_STEP);
         //-- detect decrement press again
         else
            vol_step = (-1.0) * SymbolInfoDouble(Symbol(), SYMBOL_VOLUME_STEP);
   double n_vol = current_volume + vol_step;
   current_volume = ValidateVolume(n_vol);
   string nstr_vol = DoubleToString(current_volume, 2);
   GuiController::SendEvent("CurrentVolume", MtGuiController.TextChange, 0, 0.0, nstr_vol);
  }

//+------------------------------------------------------------------+
//void  OnChartEvent(
//   const int       id,
//   const long&     lparam,   // long type event parameter
//   const double&   dparam,   // double type event parameter
//   const string&   sparam    // string type event parameter
//)
//  {
//   double ask = SymbolInfoDouble(Symbol(), SYMBOL_ASK);
//   double bid = SymbolInfoDouble(Symbol(), SYMBOL_BID);
//  GuiController::SendEvent("AskLabel", MtGuiController.TextChange, 0, 0.0, DoubleToString(ask, Digits()));
//   GuiController::SendEvent("BidLabel", MtGuiController.TextChange, 0, 0.0, DoubleToString(bid, Digits()));
//  }
//+------------------------------------------------------------------+
