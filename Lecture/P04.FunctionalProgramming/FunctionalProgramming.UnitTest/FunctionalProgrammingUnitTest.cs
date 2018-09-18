﻿//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TP.FunctionalProgramming
{
  [TestClass]
  public class FunctionalProgrammingUnitTest
  {

    [TestMethod]
    public void NamedMethodCallBackTest()
    {
      Lambda _newLambda = new Lambda();
      CallBackTestClass _callBackResult = new CallBackTestClass();
      Assert.IsFalse(_callBackResult.m_TestResult);
      _newLambda.ConsistencyCheck(new Lambda.CallBackTestDelegate(_callBackResult.CallBackTestResult));
      Assert.IsTrue(_callBackResult.m_TestResult);
    }

    [TestMethod]
    public void LambdaCallTest()
    {
      Lambda _newLambda = new Lambda();
      bool _testResult = false;
      _newLambda.ConsistencyCheck((bool _result) => _testResult = _result);
      Assert.IsTrue(_testResult);
    }
    [TestMethod]
    public void AnonymousMethodTest()
    {

      Lambda _newLambda = new Lambda();
      bool _testResult = false;
      Lambda.CallBackTestDelegate _CallBackTestResult = delegate (bool _result) { _testResult = _result; };
      _newLambda.ConsistencyCheck(_CallBackTestResult);
      Assert.IsTrue(_testResult);

    }
    [TestMethod]
    public void LambdaSyntaxTest()
    {
      const int _length = 10000;
      Random _newRandom = new Random();
      int[] _buffer = new int[_length];
      for (int i = 0; i < _length; i++)
        _buffer[i] = _newRandom.Next(0, 100);
      int _count = _buffer.Count((int x) => { return x >= 50; });
      Assert.IsTrue(_count > _length / 2 - 70 && _count < _length / 2 + 70, $"{nameof(_count)}={_count}");
    }
    private class CallBackTestClass
    {
      internal bool m_TestResult = false;
      internal void CallBackTestResult(bool returnResult)
      {
        m_TestResult = returnResult;
      }
    }


  }
}