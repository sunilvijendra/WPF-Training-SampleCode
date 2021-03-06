
// HelloWorldMFCView.cpp : implementation of the CHelloWorldMFCView class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "HelloWorldMFC.h"
#endif

#include "HelloWorldMFCDoc.h"
#include "HelloWorldMFCView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CHelloWorldMFCView

IMPLEMENT_DYNCREATE(CHelloWorldMFCView, CView)

BEGIN_MESSAGE_MAP(CHelloWorldMFCView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CHelloWorldMFCView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
END_MESSAGE_MAP()


//namespace ManagedCode
//{
//	using namespace System;
//	using namespace System::Windows;
//	using namespace System::Windows::Interop;
//	using namespace System::Windows::Media;
//	using namespace WPFClock;
//
//	HWND GetHwnd(HWND parent, int x, int y, int width, int height) {
//		HwndSource^ source = gcnew HwndSource(
//			0, // class style
//			WS_VISIBLE | WS_CHILD, // style
//			0, // exstyle
//			x, y, width, height,
//			"hi", // NAME
//			IntPtr(parent)        // parent window 
//		);
//
//		//UIElement^ page = gcnew WPFClock::Clock();
//		//WPFClock::MyWPFUserControl^ control = gcnew WPFClock::MyWPFUserControl();
//		UIElement^ control = gcnew WPFClock::MyWPFUserControl();
//		source->RootVisual = control;
//		return (HWND)source->Handle.ToPointer();
//	}
//}

// CHelloWorldMFCView construction/destruction

CHelloWorldMFCView::CHelloWorldMFCView()
{
	// TODO: add construction code here
	//HWND clock = ManagedCode::GetHwnd(tthi 0, 0, 200, 200);
	//System::Windows::Interop::HwndSource^ hws = ManagedCode::HwndSource::FromHwnd(System::IntPtr(clock));

}

CHelloWorldMFCView::~CHelloWorldMFCView()
{
}

BOOL CHelloWorldMFCView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CHelloWorldMFCView drawing

void CHelloWorldMFCView::OnDraw(CDC* /*pDC*/)
{
	CHelloWorldMFCDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
}


// CHelloWorldMFCView printing


void CHelloWorldMFCView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CHelloWorldMFCView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CHelloWorldMFCView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CHelloWorldMFCView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CHelloWorldMFCView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CHelloWorldMFCView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CHelloWorldMFCView diagnostics

#ifdef _DEBUG
void CHelloWorldMFCView::AssertValid() const
{
	CView::AssertValid();
}

void CHelloWorldMFCView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CHelloWorldMFCDoc* CHelloWorldMFCView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CHelloWorldMFCDoc)));
	return (CHelloWorldMFCDoc*)m_pDocument;
}
#endif //_DEBUG


// CHelloWorldMFCView message handlers
